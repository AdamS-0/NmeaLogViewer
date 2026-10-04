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
    public class RegexOption {
        public Regex rx = new Regex("");
        public string NmeName = "";
        
        public List<float> LineIds = new List<float>();
        public List<List<float>> Values = new List<List<float>>();
        
        public RegexOption() { }
        
        public RegexOption(string pattern) {
            this.rx = new Regex( pattern );
        }
        
        static public RegexOption parseLine(string line) {
            RegexOption rgo = new RegexOption();
            try {
                Regex rx = new Regex("(?<NmeName>.*?)<=(?<rgxPattern>.*)");
                Match m = rx.Match( line );
                if ( !m.Success ) { return null; }
                
                rgo.NmeName = m.Groups["NmeName"].ToString();
                rgo.rx = new Regex( m.Groups["rgxPattern"].Value, RegexOptions.Compiled );
                
                rgo.Values = new List<List<float>>();
                
                int groupsNumber = rgo.rx.GetGroupNames().Length;
                for ( int idx = 0; idx < groupsNumber; idx++ ) {
                    rgo.Values.Add( new List<float>() );
                }
                
                return rgo;
            }
            catch {}
            return null;
        }
    }
}
