/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 03.10.2026
 * Time: 09:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NmeaLogViewer {
    /// <summary>
    /// Description of NmeaLine.
    /// </summary>
    public class NmeaLine {
        
        public int LineId = 0;
        public string Nmea = "";
        public int LineLength = 0;
        public bool CorrectNmea = false;
        
        public string NmeId = "";
        
        public NmeaLine() { }
        
        public NmeaLine(int idxLine, string nmea, ref NmeaCntr cntrs ) {
            if ( nmea == null ) throw new ArgumentNullException("nmea");
            this.LineId = idxLine;
            int idxDollar = -1;
            int idxAsterix = -1;
            
            this.CorrectNmea = checkNMEA( nmea.ToCharArray(), ref idxDollar, ref idxAsterix, ref cntrs );
            if ( this.CorrectNmea ) {
                this.Nmea = nmea;
                this.LineLength = idxAsterix - idxDollar + 4;
                int idxComa = this.Nmea.IndexOf(',');
                if ( idxComa > 0 ) { this.NmeId = this.Nmea.Substring( 0, idxComa ); }
            } else {
                this.LineLength = 0;
            }
        }
        
        public NmeaLine( int idxLine, char[] nmea, ref NmeaCntr cntrs ) {
            if ( nmea == null ) throw new ArgumentNullException("nmea");
            this.LineId = idxLine;
            int idxDollar = -1;
            int idxAsterix = -1;
            
            this.CorrectNmea = checkNMEA( nmea, ref idxDollar, ref idxAsterix, ref cntrs );
            if ( this.CorrectNmea ) {
                this.Nmea = (nmea.ToString()).Substring(idxDollar, idxAsterix + 4);
                this.LineLength = idxAsterix - idxDollar + 4;
                int idxComa = this.Nmea.IndexOf(',');
                if ( idxComa > 0 ) { this.NmeId = this.Nmea.Substring( 0, idxComa ); }
            } else {
                this.LineLength = 0;
            }
        }
        
        
        public static bool checkNMEA( byte[] nmeaLine, ref int idxDollar, ref int idxAsterix, ref NmeaCntr cntrs ) {
            /* Calculate checksum */
            idxDollar  = -1;
            idxAsterix = -1;
            
            int idx = 0;
            for ( ; idx < nmeaLine.Length; idx++ ) {
                if ( nmeaLine[idx] != '$' ) { continue; }
                idxDollar = idx;
                break;
            }
            
            if ( idxDollar  < 0 ) { cntrs.MissingDollar++; return false; }
            
            for ( ; idx < nmeaLine.Length; idx++ ) {
                if ( nmeaLine[idx] != '*' ) { continue; }
                idxAsterix = idx;
                break;
            }
            
            if ( idxDollar  >= idxAsterix   ) { cntrs.IncorrectSyntax++; return false; }
            if ( idxAsterix < 0             ) { cntrs.MissingAsterix++; return false; }
            
            byte checksum = 0;
            for ( idx = idxDollar + 1; idx < idxAsterix; idx++ ) { checksum ^= (byte)nmeaLine[ idx ]; }
            
            /* NMEA sequence was found, Checksum can be compared */
            if ( ( idxAsterix < 0 ) ) { cntrs.MissingAsterix++; return false; }
            if ( ( idxAsterix + 3) > nmeaLine.Length ) { cntrs.MissingChk++; return false; }
            
            byte cChk1 = nmeaLine[idxAsterix + 1];
            byte cChk2 = nmeaLine[idxAsterix + 2];
            byte chk1 = 0;
            byte chk2 = 0;
            
            if      ( ( cChk1 >= '0' ) && ( cChk1 <= '9' ) ) { chk1 = (byte)(cChk1 - '0'); }
            else if ( ( cChk1 >= 'a' ) && ( cChk1 <= 'f' ) ) { chk1 = (byte)(10 + cChk1 - 'a'); }
            else if ( ( cChk1 >= 'A' ) && ( cChk1 <= 'F' ) ) { chk1 = (byte)(10 + cChk1 - 'A'); }
            
            if      ( ( cChk2 >= '0' ) && ( cChk2 <= '9' ) ) { chk2 = (byte)(cChk2 - '0'); }
            else if ( ( cChk2 >= 'a' ) && ( cChk2 <= 'f' ) ) { chk2 = (byte)(10 + cChk2 - 'a'); }
            else if ( ( cChk2 >= 'A' ) && ( cChk2 <= 'F' ) ) { chk2 = (byte)(10 + cChk2 - 'A'); }
            int chkInLine = ( chk1 << 4 ) | chk2;
            
            bool chkOk = chkInLine == (int)checksum;
            if ( chkOk )    { cntrs.ChkOk++; }
            else            { cntrs.ChkNok++; }
            
            return chkOk;
        }
        
        public static bool checkNMEA( char[] nmeaLine, ref int idxDollar, ref int idxAsterix, ref NmeaCntr cntrs ) {
            /* Calculate checksum */
            idxDollar  = -1;
            idxAsterix = -1;
            
            int idx = 0;
            for ( ; idx < nmeaLine.Length; idx++ ) {
                if ( nmeaLine[idx] != '$' ) { continue; }
                idxDollar = idx;
                break;
            }
            
            if ( idxDollar  < 0 ) {  cntrs.MissingDollar++; return false; }
            
            for ( ; idx < nmeaLine.Length; idx++ ) {
                if ( nmeaLine[idx] != '*' ) { continue; }
                idxAsterix = idx;
                break;
            }
            
            if ( idxDollar  >= idxAsterix   ) { cntrs.IncorrectSyntax++; return false; }
            if ( idxAsterix < 0             ) { cntrs.MissingAsterix++; return false; }
            
            byte checksum = 0;
            for ( idx = idxDollar + 1; idx < idxAsterix; idx++ ) { checksum ^= (byte)nmeaLine[ idx ]; }
            
            /* NMEA sequence was found, Checksum can be compared */
            if ( ( idxAsterix < 0 ) ) { cntrs.MissingAsterix++; return false; }
            if ( ( idxAsterix + 3) > nmeaLine.Length ) { cntrs.MissingChk++; return false; }
            
            char cChk1 = nmeaLine[idxAsterix + 1];
            char cChk2 = nmeaLine[idxAsterix + 2];
            byte chk1 = 0;
            byte chk2 = 0;
            
            if      ( ( cChk1 >= '0' ) && ( cChk1 <= '9' ) ) { chk1 = (byte)(cChk1 - '0'); }
            else if ( ( cChk1 >= 'a' ) && ( cChk1 <= 'f' ) ) { chk1 = (byte)(10 + cChk1 - 'a'); }
            else if ( ( cChk1 >= 'A' ) && ( cChk1 <= 'F' ) ) { chk1 = (byte)(10 + cChk1 - 'A'); }
            
            if      ( ( cChk2 >= '0' ) && ( cChk2 <= '9' ) ) { chk2 = (byte)(cChk2 - '0'); }
            else if ( ( cChk2 >= 'a' ) && ( cChk2 <= 'f' ) ) { chk2 = (byte)(10 + cChk2 - 'a'); }
            else if ( ( cChk2 >= 'A' ) && ( cChk2 <= 'F' ) ) { chk2 = (byte)(10 + cChk2 - 'A'); }
            int chkInLine = ( chk1 << 4 ) | chk2;
            
            bool chkOk = chkInLine == (int)checksum;
            if ( chkOk )    { cntrs.ChkOk++; }
            else            { cntrs.ChkNok++; }
            
            return chkOk;
        }
    }
    
    public class NmeaCntr {
        public int IncorrectSyntax  = 0;
        public int ChkOk            = 0;
        public int ChkNok           = 0;
        public int MissingDollar    = 0;
        public int MissingAsterix   = 0;
        public int MissingChk       = 0;
        
        public NmeaCntr() { }
    }
}
