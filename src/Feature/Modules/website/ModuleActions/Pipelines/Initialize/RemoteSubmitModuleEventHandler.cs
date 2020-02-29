using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using xTeam.Feature.Modules.ModuleActions.Events;

namespace xTeam.Feature.Modules.ModuleActions.Pipelines.Initialize
{
    public class RemoteSubmitModuleEventHandler
    {
        public virtual void Initialize(PipelineArgs args)
        {
            var action = new Action<RemoteSubmitModuleEvent>(RaiseRemoteEvent);
            Sitecore.Eventing.EventManager.Subscribe<RemoteSubmitModuleEvent>(action);
        }

        private void RaiseRemoteEvent(RemoteSubmitModuleEvent myEvent)
        {
            Sitecore.Events.Event.RaiseEvent("cache:clear:remote");
        }

    }
}