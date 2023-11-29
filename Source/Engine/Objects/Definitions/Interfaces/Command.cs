using OpenQA.Selenium;
using System.Collections;

namespace Engine.Objects.Definitions.Interfaces
{
    public interface ICommand
    {
        public string? Id { get; set; }
        public string? Comment { get; set; }
        public string? Command { get; set; }
        public string? Description { get; set; }
        public string? Target { get; set; }
        public IList? Targets { get; set; }
        public string? Value { get; set; }
        public bool OpensWindow { get; set; }
        public string? WindowHandleName { get; set; }
        public int WindowTimeout { get; set; }

        public int Execute(IWebDriver? driver, IDictionary<string, object> testVars);

        //BROWSER INTERACTIONS
        #region ASSERTIONS
        public int Assert();
        public int AssertAlert();
        public int AssertChecked();
        public int AssertNotChecked();
        public int AssertConfirmation();
        public int AssertEditable();
        public int AssertNotEditable();
        public int AssertElementPresent();
        public int AssertElementNotPresent();
        public int AssertSelectedValue();
        public int AssertNotSelectedValue();
        public int AssertSelectedLabel();
        public int AssertText();
        public int AssertNotText();
        public int AssertPrompt();
        public int AssertTitle();
        public int AssertValue();
        public int Verify();
        public int VerifyChecked();
        public int VerifyEditable();
        public int VerifyElementPresent();
        public int VerifyElementNotPresent();
        public int VerifyNotChecked();
        public int VerifyNotEditable();
        public int VerifyNotSelectedValue();
        public int VerifyText();
        public int VerifyTitle();
        public int VerifyValue();
        #endregion
        #region WINDOW ACTIONS
        public int Open();
        public int Close();
        public int SetWindowSize();
        public int SelectWindow(IDictionary<string, object> vars);
        public int SelectFrame();
        public int StoreWindowHandle(IDictionary<string, object> vars);
        #endregion
        #region MOUSE ACTIONS
        public int MouseUp();
        public int MouseOver();
        public int MouseDown();
        public int Click(IDictionary<string, object> vars);
        public int ClickAt();
        public int DoubleClick();
        public int DoubleClickAt();
        public int DragAndDropToObject();
        public int MouseDownAt();
        public int MouseMoveAt();
        public int MouseOut();
        public int MouseUpAt();
        #endregion
        #region KEYBOARD ACTIONS
        public int Type();
        public int SendKeys();
        #endregion
        #region STORE OPERATIONS
        public int Store();
        public int StoreAttribute();
        public int StoreJson();
        public int StoreText();
        public int StoreTitle();
        public int StoreValue();
        public int StoreXpathCount();
        #endregion
        #region BROWSER ACTIONS
        public int Select();
        public int AddSelection();
        public int RemoveSelection();
        public int AnswerOnNextPrompt();
        public int ChooseCancelOnNextPrompt();
        public int ChooseOkOnNextPrompt();
        public int ChooseOkOnNextConfirmation();
        public int ChooseCancelOnNextConfirmation();
        public int Check();
        public int Uncheck();
        public int EditContent();
        public int Submit();
        public int WaitForElementEditable();
        public int WaitForElementNotEditable();
        public int WaitForElementNotPresent();
        public int WaitForElementNotVisible();
        public int WaitForText();
        #endregion
        #region WEBDRIVER ACTIONS
        public int WebdriverAnswerOnVisiblePrompt();
        public int WebdriverChooseCancelOnVisibleConfirmation();
        public int WebdriverChooseCancelOnVisiblePrompt();
        public int WebdriverChooseOkOnVisibleConfirmation();
        #endregion
        #region SCRIPTING
        public int Times();
        public int Do();
        public int While();
        public int If();
        public int Else();
        public int Pause();
        public int RepeatIf();
        public int ExecuteScript();
        public int ExecuteAsyncScript();
        public int ForEach();
        public int Debugger();
        public int Echo();
        public int ElseIf();
        public int End();
        public int Run();
        public int RunScript();
        public int SetSpeed();
        #endregion
    }
}
