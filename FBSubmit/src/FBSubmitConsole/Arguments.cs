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

namespace FBSubmit.FBSubmitConsole
{
    public class Arguments : IArguments
    {
        private readonly string m_AreaName;

        private readonly string m_DefaultReplyMessage;

        private readonly string m_Description;
        private readonly string m_EmailToReplyTo;

        private readonly string m_ExtraInformation;
        private readonly bool m_ForceNewBug;
        private readonly string m_OpenAsUser;

        private readonly string m_ProjectName;
        private readonly string m_URL;

        public Arguments(string url,
                         string openAsUser,
                         string projectName,
                         string areaName,
                         string emailToReplyTo,
                         bool forceNewBug,
                         string defaultReplyMessage,
                         string description,
                         string extraInformation)
        {
            m_URL = url;
            m_OpenAsUser = openAsUser;
            m_ProjectName = projectName;
            m_AreaName = areaName;
            m_EmailToReplyTo = emailToReplyTo;
            m_ForceNewBug = forceNewBug;
            m_DefaultReplyMessage = defaultReplyMessage;
            m_Description = description;
            m_ExtraInformation = extraInformation;
        }

        #region IArguments Members

        public string URL
        {
            get { return m_URL; }
        }

        public string OpenAsUser
        {
            get { return m_OpenAsUser; }
        }

        public string ProjectName
        {
            get { return m_ProjectName; }
        }

        public string AreaName
        {
            get { return m_AreaName; }
        }

        public string EmailToReplyTo
        {
            get { return m_EmailToReplyTo; }
        }

        public string DefaultReplyMessage
        {
            get { return m_DefaultReplyMessage; }
        }

        public bool ForceNewBug
        {
            get { return m_ForceNewBug; }
        }

        public string Description
        {
            get { return m_Description; }
        }

        public string ExtraInformation
        {
            get { return m_ExtraInformation; }
        }

        #endregion
    }
}