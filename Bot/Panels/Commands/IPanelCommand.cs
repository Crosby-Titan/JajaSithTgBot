namespace Bot.Panels.Commands
{
    public interface IPanelCommand
    {
        public string Name { get; set; }
        public IControlPanel.CommandDelegateHandler Action { get; set; }
    }
}
