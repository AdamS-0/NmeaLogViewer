/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 03.10.2026
 * Time: 20:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NmeaLogViewer {
    // [NmeName]<=[pattern]
    public class RegexOption : IDisposable {
        
        public enum RegexOptionParseStatus {
            Ok,
            MissingName,
            MissingPattern,
            ArrowNotFound,
            Error
        }
        
        public Regex rx = new Regex("");
        public string NmeName = "";
        
        public List<float> LineIds = new List<float>();
        public List<List<float>> Values = new List<List<float>>();
        
        public RegexOption() { }
        
        public RegexOption(string pattern) {
            this.rx = new Regex( pattern );
        }
        
        static public RegexOption parseLine(string line, out RegexOptionParseStatus status) {
            status = RegexOptionParseStatus.Error;
            RegexOption rgo = new RegexOption();
            try {
                int idxArrow = line.IndexOf( "<=" );
                if ( idxArrow < 0 ) {
                    status = RegexOptionParseStatus.ArrowNotFound;
                    return null;
                } else if ( idxArrow == 0 ) {
                    status = RegexOptionParseStatus.MissingName;
                    return null;
                } else if ( idxArrow + 2 >= line.Length ) {
                    status = RegexOptionParseStatus.MissingPattern;
                    return null;
                }
                
                Regex rx = new Regex("(?<NmeName>.*?)<=(?<rgxPattern>.*)");
                Match m = rx.Match( line );
                if ( !m.Success ) {  return null; }
                
                rgo.NmeName = m.Groups["NmeName"].ToString();
                rgo.rx = new Regex( m.Groups["rgxPattern"].Value, RegexOptions.Compiled );
                
                rgo.Values = new List<List<float>>();
                
                int groupsNumber = rgo.rx.GetGroupNames().Length;
                for ( int idx = 0; idx < groupsNumber; idx++ ) {
                    rgo.Values.Add( new List<float>() );
                }
                
                status = RegexOptionParseStatus.Ok;
                return rgo;
            }
            catch {}
            return null;
        }

        #region IDisposable implementation

        public void Dispose() {
            rx = null;
            NmeName = null;
            if ( LineIds != null ) { LineIds.Clear(); LineIds = null; }
            if ( Values != null ) {
                foreach( List<float> valList in Values ) {
                    if ( valList != null ) {
                        valList.Clear();
                    }
                }
                Values.Clear();
                Values = null;
            }
        }

        #endregion
    }
}
