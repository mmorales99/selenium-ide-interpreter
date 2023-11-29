using Engine.Objects.Definitions.Interfaces;
using OpenQA.Selenium;
using System.Collections;

namespace Engine.Objects.Definitions.Abstracts
{
    public abstract class AbsCommand : ICommand
    {
        public abstract string? Id { get; set; }
        public abstract string? Comment { get; set; }
        public abstract string? Command { get; set; }
        public abstract string? Description { get; set; }
        public abstract string? Target { get; set; }
        public IList? Targets { get; set; }
        public abstract string? Value { get; set; }
        public abstract bool OpensWindow { get; set; }
        public abstract string? WindowHandleName { get; set; }
        public abstract int WindowTimeout { get; set; }

        public abstract int Execute(IWebDriver? driver, IDictionary<string, object> TestVars);
        public abstract void Dispose();

        public abstract int AddSelection();
        public abstract int AnswerOnNextPrompt();
        public abstract int Assert();
        public abstract int AssertAlert();
        public abstract int AssertChecked();
        public abstract int AssertConfirmation();
        public abstract int AssertEditable();
        public abstract int AssertElementNotPresent();
        public abstract int AssertElementPresent();
        public abstract int AssertNotChecked();
        public abstract int AssertNotEditable();
        public abstract int AssertNotSelectedValue();
        public abstract int AssertNotText();
        public abstract int AssertPrompt();
        public abstract int AssertSelectedLabel();
        public abstract int AssertSelectedValue();
        public abstract int AssertText();
        public abstract int AssertTitle();
        public abstract int AssertValue();
        public abstract int Check();
        public abstract int ChooseCancelOnNextConfirmation();
        public abstract int ChooseCancelOnNextPrompt();
        public abstract int ChooseOkOnNextConfirmation();
        public abstract int ChooseOkOnNextPrompt();
        public abstract int Click(IDictionary<string, object> vars);
        public abstract int ClickAt();
        public abstract int Close();
        public abstract int Debugger();
        public abstract int Do();
        public abstract int DoubleClick();
        public abstract int DoubleClickAt();
        public abstract int DragAndDropToObject();
        public abstract int Echo();
        public abstract int EditContent();
        public abstract int Else();
        public abstract int ElseIf();
        public abstract int End();
        public abstract int ExecuteAsyncScript();
        public abstract int ExecuteScript();
        public abstract int ForEach();
        public abstract int If();
        public abstract int MouseDown();
        public abstract int MouseDownAt();
        public abstract int MouseMoveAt();
        public abstract int MouseOut();
        public abstract int MouseOver();
        public abstract int MouseUp();
        public abstract int MouseUpAt();
        public abstract int Open();
        public abstract int Pause();
        public abstract int RemoveSelection();
        public abstract int RepeatIf();
        public abstract int Run();
        public abstract int RunScript();
        public abstract int Select();
        public abstract int SelectFrame();
        public abstract int SelectWindow(IDictionary<string, object> vars);
        public abstract int SendKeys();
        public abstract int SetSpeed();
        public abstract int SetWindowSize();
        public abstract int Store();
        public abstract int StoreAttribute();
        public abstract int StoreJson();
        public abstract int StoreText();
        public abstract int StoreTitle();
        public abstract int StoreValue();
        public abstract int StoreWindowHandle(IDictionary<string, object> vars);
        public abstract int StoreXpathCount();
        public abstract int Submit();
        public abstract int Times();
        public abstract int Type();
        public abstract int Uncheck();
        public abstract int Verify();
        public abstract int VerifyChecked();
        public abstract int VerifyEditable();
        public abstract int VerifyElementNotPresent();
        public abstract int VerifyElementPresent();
        public abstract int VerifyNotChecked();
        public abstract int VerifyNotEditable();
        public abstract int VerifyNotSelectedValue();
        public abstract int VerifyText();
        public abstract int VerifyTitle();
        public abstract int VerifyValue();
        public abstract int WaitForElementEditable();
        public abstract int WaitForElementNotEditable();
        public abstract int WaitForElementNotPresent();
        public abstract int WaitForElementNotVisible();
        public abstract int WaitForText();
        public abstract int WebdriverAnswerOnVisiblePrompt();
        public abstract int WebdriverChooseCancelOnVisibleConfirmation();
        public abstract int WebdriverChooseCancelOnVisiblePrompt();
        public abstract int WebdriverChooseOkOnVisibleConfirmation();
        public abstract int While();
    }
}
