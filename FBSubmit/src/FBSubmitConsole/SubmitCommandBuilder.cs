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
    public class SubmitCommandBuilder
    {
        private string m_AreaName;
        private string m_DefaultReply;
        private string m_Desc;
        private string m_Email;
        private string m_ExtraInfo;
        private bool m_ForceNew;
        private string m_Project;
        private string m_Url;
        private string m_User;

        public SubmitCommandBuilder WithUrl(string submitUrl)
        {
            m_Url = submitUrl;
            return this;
        }


        public SubmitCommand Build()
        {
            return new SubmitCommand(m_Url,
                                     m_User,
                                     m_Project,
                                     m_AreaName,
                                     m_Email,
                                     m_ForceNew,
                                     m_DefaultReply,
                                     m_Desc,
                                     m_ExtraInfo);
        }

        public SubmitCommandBuilder WithUser(string user)
        {
            m_User = user;
            return this;
        }

        public SubmitCommandBuilder WithProject(string project)
        {
            m_Project = project;
            return this;
        }

        public SubmitCommandBuilder WithArea(string area)
        {
            m_AreaName = area;
            return this;
        }

        public SubmitCommandBuilder WithEmail(string email)
        {
            m_Email = email;
            return this;
        }

        public SubmitCommandBuilder WithForceNew(string foreceNew)
        {
            bool force;
            bool.TryParse(foreceNew, out force);

            m_ForceNew = force;
            return this;
        }

        public SubmitCommandBuilder WithDefaultMessage(string defMsg)
        {
            m_DefaultReply = defMsg;
            return this;
        }

        public SubmitCommandBuilder WithDescription(string description)
        {
            m_Desc = description;
            return this;
        }

        public SubmitCommandBuilder WithExtraInfo(string extraInfo)
        {
            m_ExtraInfo = extraInfo;
            return this;
        }
    }
}