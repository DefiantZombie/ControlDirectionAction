namespace ControlDirectionAction
{
    public class ModuleControlDirectionAction : PartModule
    {
        protected ModuleControlSurface _surfaceModule;
        protected bool _ready = false;

        public override void OnStart(StartState state)
        {
            base.OnStart(state);

            _surfaceModule = part.Modules.GetModule<ModuleControlSurface>();
            if (_surfaceModule == null)
            {
                part.RemoveModule(this);
                Destroy(this);
            }
            else
            {
                _ready = true;
            }
        }

        [KSPAction("#SSC_ControlDirectionAction_000001",
            advancedTweakable = true, requireFullControl = false)]
        public void ToggleControl(KSPActionParam param)
        {
            if (!_ready) return;

            _surfaceModule.deployInvert = !_surfaceModule.deployInvert;
        }
    }
}
