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

namespace Frostbyte.Classes.Project
{
    public class FileType
    {
        public static FileType SQF = new FileType("sqf", "SQF", 2);
        public static FileType SQM = new FileType("sqm", "SQM", 2);
        public static FileType H = new FileType("h", "H", 2);
        public static FileType HPP = new FileType("hpp", "HPP", 2);
        public static FileType EXT = new FileType("ext", "EXT", 2);
        public static FileType XML = new FileType("xml", "XML", 3);
        public static FileType TXT = new FileType("txt", "TXT", 4);
        public static FileType UNKNOWN = new FileType("unknown", "Unknown", 2);
        public static Dictionary<string, FileType> values;

        public string Extension;
        public string FriendlyName;
        public int IconIndex;

        public FileType(string extension, string friendlyName, int iconIndex)
        {
            this.Extension = extension;
            this.FriendlyName = friendlyName;
            this.IconIndex = iconIndex;

            if (values == null)
            {
                values = new Dictionary<string, FileType>();
            }

            values.Add(extension, this);
        }

        public static FileType GetByExtension(string extension)
        {
            if (values != null && values.ContainsKey(extension))
            {
                return values[extension];
            }

            return UNKNOWN;
        }

    }
}
