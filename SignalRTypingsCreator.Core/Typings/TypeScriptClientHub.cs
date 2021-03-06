﻿using System;
using System.Linq;
using System.Text;
using SignalRTypingsCreator.Core.Hubs;
using SignalRTypingsCreator.Core.Typings.Methods;
using SignalRTypingsCreator.Core.Typings.Models;
using SignalRTypingsCreator.Core.Typings.Naming;

namespace SignalRTypingsCreator.Core.Typings
{
    public class TypeScriptClientHub
    {
        private readonly Type _clientHubType;
        private readonly string _hubName;
        private readonly TypeScriptMethodList _methodList;

        public TypeScriptClientHub(Type clientHubType, string hubName)
        {
            _clientHubType = clientHubType;
            _hubName = hubName;
            _methodList = new TypeScriptMethodList(_clientHubType);
        }

        public void CreateHubClientInterface(StringBuilder stringBuilder)
        {
            if (_clientHubType == null)
            {
                return;
            }

            stringBuilder.AppendLine($"interface {GetHubClientTypeName()} {{");
            _methodList.GenerateMethodDefinitions(stringBuilder);
            stringBuilder.AppendLine("}");
        }

        public void AddModelsToCollection(TypeScriptModelList modelCollection)
        {
            _methodList.AddModelsToCollection(modelCollection);
        }

        public string GetHubClientTypeName()
        {
            return _clientHubType == null
                                        ? "any"
                                        : $"{_hubName}Client";
        }
    }
}