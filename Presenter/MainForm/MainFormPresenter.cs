namespace TDGPGasReader.Presenter.MainForm
{
    using TDGPGasReader.Presenter.MainForm.Interfaces;
    using TDGPGasReader.Views.Main.Interfaces;

    public class MainFormPresenter : IMainFormPresenter
    {
        private IForm1View _form1;

        public MainFormPresenter() { }

        public void SetView(IForm1View view)
        {
            this._form1 = view;
        }
    }
}
