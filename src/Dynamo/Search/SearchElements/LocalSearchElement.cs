﻿//Copyright © Autodesk, Inc. 2012. All rights reserved.
//
//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at
//
//http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

using System;
using System.Collections.Generic;
using Dynamo.Commands;
using Dynamo.Nodes;

namespace Dynamo.Search
{
    /// <summary>
    /// A search element representing a local node </summary>
    public class LocalSearchElement : SearchElementBase
    {

        #region Properties
        /// <summary>
        /// Node property </summary>
        /// <value>
        /// The node used to instantiate this object </value>
        public dynNode Node { get; internal set; }

        /// <summary>
        /// Type property </summary>
        /// <value>
        /// A string describing the type of object </value>
        public override string Type { get { return "Standard Node"; } }

        /// <summary>
        /// Name property </summary>
        /// <value>
        /// The name of the node </value>
        public override string Name { get { return Node.NodeUI.NickName; } }

        /// <summary>
        /// Description property </summary>
        /// <value>
        /// A string describing what the node does</value>
        public override string Description { get { return Node.NodeUI.Description; } }

        /// <summary>
        /// Weight property </summary>
        /// <value>
        /// Number defining the relative importance of the element in search.  Higher the better </value>
        public override double Weight { get; set; }

        /// <summary>
        /// Keywords property </summary>
        /// <value>
        /// Joined set of keywords </value>
        public override string Keywords { get; set; }

        #endregion

        /// <summary>
        /// The class constructor. </summary>
        /// <param name="node">The local node</param>
        public LocalSearchElement(dynNode node)
        {
            this.Node = node;
            this.Weight = 1;
            this.Keywords = String.Join(" ", node.NodeUI.Tags);
        }

        /// <summary>
        /// Executes the element in search, this is what happens when the user 
        /// hits enter in the SearchView.</summary>
        public override void Execute()
        {
            DynamoCommands.CreateNodeCmd.Execute(new Dictionary<string, object>()
                {
                    {"name", this.Name},
                    {"transformFromOuterCanvasCoordinates", true},
                    {"guid", Guid.NewGuid() }
                });
        }

    }

}