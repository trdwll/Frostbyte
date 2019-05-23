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

namespace Frostbyte.Classes
{
    class Configuration
    {
        /// <summary>
        /// To expose line numbers on try catch statements etc
        /// </summary>
        public static bool DEBUGMODE = true;



        /// <summary>
        /// Application version
        /// </summary>
        public static readonly double version = 0.1;

        /// <summary>
        /// Application release date
        /// </summary>
        public static readonly string ReleaseDate = "10OCT15";

        /// <summary>
        /// Release code name
        /// </summary>
        public static readonly string ReleaseCodeName = "Alpaca";

        /// <summary>
        /// Where the updater fetches the update file 
        /// </summary>
        public static readonly string UpdateURL = "https://www.trdwll.com/frostbyte.txt";

        /// <summary>
        /// The download to get when there's an update
        /// </summary>
        public static readonly string DownloadURL = "";



        // ================== Application set settings ==================

        /// <summary>
        /// Check for updates on application start
        /// </summary>
        public static bool s_CheckForUpdatesAutomatically = Properties.Settings.Default.CheckForUpdatesAutomatically;

        /// <summary>
        /// The string that goes on the beginning of each file
        /// </summary>
        public static string s_TopFileComment = Properties.Settings.Default.TopFileComment;
    }
}
