/**
 * Frostbyte
 *
 * Frostbyte is an open source software licensed under the Apache 2.0 license.
 *
 * www.trdwll.com
 *
 *
 *  Copyright 2015-2019 Russ 'trdwll' Treadwell and Jack 'OhYea777' Taylor
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Frostbyte.Classes.Arma3
{
    class MapList
    {
        public static MapList NONE = new MapList("None");
        public static MapList ALTIS = new MapList("Altis", new MapFile[] { new MapFile("mission.sqm", "data/altis_mission.sqm") });
        public static MapList STRATIS = new MapList("Stratis", new MapFile[] { new MapFile("mission.sqm", "data/stratis_mission.sqm") });
        public static MapList VR = new MapList("Virtual Reality", new MapFile[] { new MapFile("mission.sqm", "data/vr_mission.sqm") });
        //  public static MapList TANOA = new MapList("Tanoa");
        // TODO: Add All in Arma Terrain Pack maps

        public static Dictionary<string, MapList> Names;

        public string FriendlyName;

        public MapFile[] MapFiles;

        public MapList(string _FriendlyName, MapFile[] _MapFiles = null)
        {
            this.FriendlyName = _FriendlyName;
            this.MapFiles = _MapFiles;
            if (Names == null)
            {
                Names = new Dictionary<string, MapList>();
            }
            Names.Add(FriendlyName, this);
        }

        public static List<string> GetMapNames()
        {
            return new List<string>(Names.Keys);
        }

        public static MapList GetByName(string Name)
        {
            if (Names != null && Names.ContainsKey(Name))
            {
                return Names[Name];
            }

            return NONE;
        }
    }

    class MapFile
    {
        public string FileName; // mission.sqm
        public string LocalFileName; // /data/map_mission.sqm

        public MapFile(string _FileName, string _LocalFileName)
        {
            this.FileName = _FileName;
            this.LocalFileName = _LocalFileName;
        }
    }
}
