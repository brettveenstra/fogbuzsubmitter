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
    public class CommandFactory : ICommandFactory
    {
        #region ICommandFactory Members

        public ICommand CreateCommand(string[] parms)
        {
            if (SubmitWithFullInfoSpecification.IsSatisifiedBy(parms))
            {
                SubmitCommandBuilder builder = new SubmitCommandBuilder();
                return builder
                        .WithUrl(parms[0])
                        .WithUser(parms[1])
                        .WithProject(parms[2])
                        .WithArea(parms[3])
                        .WithEmail(parms[4])
                        .WithForceNew(parms[5])
                        .WithDefaultMessage(parms[6])
                        .WithDescription(parms[7])
                        .WithExtraInfo(parms[8])
                        .Build();
            }
            return new HelpCommand();
        }

        #endregion
    }
}