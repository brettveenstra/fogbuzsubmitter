#region copyright

// Copyright (c) 2009, Brett L. Veenstra
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice, this 
// 		list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice, 
// 		this list of conditions and the following disclaimer in the documentation 
// 		and/or other materials provided with the distribution.
//     * Neither the name of the <ORGANIZATION> nor the names of its contributors may 
// 		be used to endorse or promote products derived from this software without 
// 		specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
// OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF 
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR 
// OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
// THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;

namespace FBSubmit.FBSubmitConsole
{
    public static class SubmitWithFullInfoSpecification
    {
        public static bool IsSatisifiedBy(string[] parms)
        {
            if (parms.Length < 8)
            {
                return false;
            }

            if (parms.Length == 9)
            {
                return UrlOk(parms[0]) &
                       UserOk(parms[1]) &
                       ProjectOk(parms[2]) &
                       AreaOk(parms[3]) &
                       EmailOk(parms[4]) &
                       ForceNewOk(parms[5]) &
                       DefaultMsgOk(parms[6]) &
                       DescriptionOk(parms[7]) &
                       ExtraInfoOk(parms[8]);
            }

            return UrlOk(parms[0]) &
                   UserOk(parms[1]) &
                   ProjectOk(parms[2]) &
                   AreaOk(parms[3]) &
                   EmailOk(parms[4]) &
                   ForceNewOk(parms[5]) &
                   DefaultMsgOk(parms[6]) &
                   DescriptionOk(parms[7]);
        }

        private static bool ExtraInfoOk(string s)
        {
            return s.Length > 0;
        }

        private static bool DescriptionOk(string s)
        {
            return s.Length > 0;
        }

        private static bool DefaultMsgOk(string s)
        {
            return s != null;
        }

        private static bool ForceNewOk(string s)
        {
            try
            {
                bool toBoolean = Convert.ToBoolean(s);
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }

        private static bool EmailOk(string s)
        {
            if (s != null)
            {
                return s.Length == 0 | s.Length > 5;
            }
            return false;
        }

        private static bool AreaOk(string s)
        {
            return s.Length > 0;
        }

        private static bool ProjectOk(string s)
        {
            return s.Length > 0;
        }

        private static bool UserOk(string s)
        {
            return s.Length > 0;
        }

        private static bool UrlOk(string s)
        {
            return s.Length > 7 & s.StartsWith("http", StringComparison.OrdinalIgnoreCase) & s.ToLower().Contains("scoutsubmit.");
        }
    }
}