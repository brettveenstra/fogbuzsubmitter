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
using System.Collections.Generic;
using MbUnit.Framework;
using Rhino.Mocks;
using Rhino.Testing.AutoMocking;

namespace FBSubmit.UnitTests.Utility
{
    public abstract class Specification
    {
        private AutoMockingContainer container;
        private MockRepository mockery;

        protected MockRepository Mocks
        {
            get { return mockery; }
        }

        protected AutoMockingContainer Container
        {
            get { return container; }
        }

        public IDisposable PlayBackOnly
        {
            get
            {
                using (Record)
                {
                }
                return PlayBack;
            }
        }

        public IDisposable Record
        {
            get { return Mocks.Record(); }
        }

        public IDisposable PlayBack
        {
            get { return Mocks.Playback(); }
        }

        [SetUp]
        public void BaseSetup()
        {
            mockery = new MockRepository();
            container = new AutoMockingContainer(mockery);
            container.Initialize();
            Before_each_spec();
        }

        [TearDown]
        public void TearDown()
        {
            After_Each_Spec();
        }

        protected virtual void After_Each_Spec()
        {
        }


        public void BackToRecord(object mockObject)
        {
            Mocks.BackToRecord(mockObject);
        }

        public abstract void Before_each_spec();


        public Item CreateSUT<Item>()
        {
            return container.Create<Item>();
        }

        public Interface CreateStrictMockOf<Interface>()
        {
            return mockery.StrictMock<Interface>();
        }

        public IEnumerable<T> CreateMockEnumerable<T>()
        {
            return CreateMock<IEnumerable<T>>();
        }

        public T Mock<T>() where T : class
        {
            return container.Get<T>();
        }

        public void ProvideAnImplementationOf<Interface, Implementation>()
        {
            container.AddComponent(typeof (Implementation).FullName, typeof (Interface), typeof (Implementation));
        }

        public void ProvideAnImplementationOf<Interface>(object instance)
        {
            container.Kernel.AddComponentInstance(instance.GetType().FullName, typeof (Interface), instance);
        }

        protected T CreateMock<T>() where T : class
        {
            return Mocks.DynamicMock<T>();
        }
    }
}