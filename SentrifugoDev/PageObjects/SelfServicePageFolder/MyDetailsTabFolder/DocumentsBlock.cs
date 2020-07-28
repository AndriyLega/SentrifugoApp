using OpenQA.Selenium;
using SentrifugoDev.CommonLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects.SelfServicePageFolder.MyDetailsTabFolder
{
    public class DocumentsBlock
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;
        protected DatePickerCalendarPlugin datePickerCalendarPlugin;
        protected TablePlugin tablePlugin;

        public DocumentsBlock(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
        }

        #region Documents Block Elements

        private const string xpathNewDocumentButton = "//input[@class ='sprite adddocment']";
        private readonly By NewDocumentButtonLocator = By.XPath(xpathNewDocumentButton);

        #region Add New Document Form Elements

        private const string xpathAddDocumentForm = "//div[@id ='emp_doc_form']";
        private readonly By AddDocumentFormLocator = By.XPath(xpathAddDocumentForm);

        private const string xpathAddDocumentFormSuccessMessage = "//div[@id ='error_message_employeedocs']//div[@id='messageData']//div";
        private readonly By AddDocumentFormSuccessMessageLocator = By.XPath(xpathAddDocumentFormSuccessMessage);

        private const string xpathDocumentNameFieldInAddDocForm = "//input[@id='document_name']";
        private readonly By DocumentNameFieldInAddDocFormLocator = By.XPath(xpathDocumentNameFieldInAddDocForm);

        private const string xpathDocumentNameFieldErrorMessageInAddDocForm = "//span[@id='errors-document_name']";
        private readonly By DocumentNameFieldErrorMessageInAddDocFormLocator = By.XPath(xpathDocumentNameFieldErrorMessageInAddDocForm);

        private const string xpathUploadAttachmentBoxInAddDocForm = "//div[@id ='emp_doc_form']//input[@name='myfile[]']";
        private readonly By UploadAttachmentBoxInAddDocFormLocator = By.XPath(xpathUploadAttachmentBoxInAddDocForm);

        private const string xpathUploadAttachmentBoxErrorMessageInAddDocForm = "//span[@id='errors-doc_attachment']";
        private readonly By UploadAttachmentBoxErrorMessageInAddDocFormLocator = By.XPath(xpathUploadAttachmentBoxErrorMessageInAddDocForm);

        private const string xpathUploadedFielsInAddDocForm = "//div[@id ='emp_doc_form']//div[@class='ajax-file-upload-statusbar']";
        private readonly By UploadedFielsInAddDocFormLocator = By.XPath(xpathUploadedFielsInAddDocForm);

        private const string xpathDeleteUploadedFielButtonInAddDocForm = "//div[@class='ajax-file-upload-red']/i";
        private readonly By DeleteUploadedFielButtonInAddDocFormLocator = By.XPath(xpathDeleteUploadedFielButtonInAddDocForm);

        private const string xpathSaveAddDocumentFormButton = "//input[@value='Save']";
        private readonly By SaveAddDocumentFormButtonLocator = By.XPath(xpathSaveAddDocumentFormButton);

        private const string xpathCancelAddDocumentFormButton = "//div[@id='emp_doc_form']//button[text()='Cancel']";
        private readonly By CancelAddDocumentFormButtonLocator = By.XPath(xpathCancelAddDocumentFormButton);

        #endregion

        private const string xpathSavedDocumentsList = "//div[@class='view_list']";
        private readonly By SavedDocumentsListLocator = By.XPath(xpathSavedDocumentsList);

        private const string xpathNameOfSavedDocument = "//div[@class='doc_name_div']";
        private readonly By NameOfSavedDocumentLocator = By.XPath(xpathNameOfSavedDocument);

        private const string xpathViewAttachmentsButtonOfSavedDocument = "//div[@class='doc_name_div']//span[@class='attach_count js_photo_gallery']/a[1]";
        private readonly By ViewAttachmentsButtonOfSavedDocumentLocator = By.XPath(xpathViewAttachmentsButtonOfSavedDocument);

        private const string xpathEditSavedDocumentButton = "//div[@class='view_list']/a[@class='edit_action_new edit_doc']";
        private readonly By EditSavedDocumentButtonLocator = By.XPath(xpathEditSavedDocumentButton);

        private const string xpathDeleteSavedDocumentButton = "//div[@class='view_list']/a[@class='edit_action_new delete_doc']";
        private readonly By DeleteSavedDocumentButtonLocator = By.XPath(xpathDeleteSavedDocumentButton);

        private const string xpathDownloadAttachmentsButtonOfSavedDocument = "//div[@class='view_list']/a[contains(@id,'download_doc')]";
        private readonly By DownloadAttachmentsButtonOfSavedDocumentLocator = By.XPath(xpathDownloadAttachmentsButtonOfSavedDocument);

        #region Add New Document Form Elements

        private const string xpathEditDocumentForm = "//div[@class='edit_emp_docs_div']";
        private readonly By EditDocumentFormLocator = By.XPath(xpathEditDocumentForm);

        private const string xpathEditDocumentFormSuccessMessage = "//div[@class='edit_emp_docs_div']//div[@id='messageData']/div";
        private readonly By EditDocumentFormSuccessMessageLocator = By.XPath(xpathEditDocumentFormSuccessMessage);

        private const string xpathDocumentNameFieldInEditDocForm = "//input[@id='edit_document_name']";
        private readonly By DocumentNameFieldInEditDocFormLocator = By.XPath(xpathDocumentNameFieldInEditDocForm);

        private const string xpathDocumentNameFieldErrorMessageInEditDocForm = "//span[@id='errors-edit_document_name']";
        private readonly By DocumentNameFieldErrorMessageInEditDocFormLocator = By.XPath(xpathDocumentNameFieldErrorMessageInEditDocForm);

        private const string xpathUploadAttachmentBoxInEditDocForm = "//div[@class='edit_emp_docs_div']//input[@name='myfile[]']";
        private readonly By UploadAttachmentBoxInEditDocFormLocator = By.XPath(xpathUploadAttachmentBoxInEditDocForm);

        private const string xpathUploadAttachmentBoxErrorMessageInEditDocForm = "//span[@id='errors-doc_attachment_edit']";
        private readonly By UploadAttachmentBoxErrorMessageInEditDocFormLocator = By.XPath(xpathUploadAttachmentBoxErrorMessageInEditDocForm);

        private const string xpathUploadedFielsInEditDocForm = "//div[@class='edit_emp_docs_div']//div[@class='ajax-file-upload-statusbar']";
        private readonly By UploadedFielsInEditDocFormLocator = By.XPath(xpathUploadedFielsInEditDocForm);

        private const string xpathDeleteUploadedFielButtonInEditDocForm = "//div[@class='edit_emp_docs_div']//a[@class='edit_action_new delete_doc']";
        private readonly By DeleteUploadedFielButtonInEditDocFormLocator = By.XPath(xpathDeleteUploadedFielButtonInEditDocForm);

        private const string xpathDownloadAttachmentButtonInEditDocForm = "//div[@class='edit_emp_docs_div']//a[@type='button']";
        private readonly By DownloadAttachmentButtonInEditDocFormLocator = By.XPath(xpathDownloadAttachmentButtonInEditDocForm);

        private const string xpathUpdateEditDocumentFormButton = "//div[@class='edit_emp_docs_div']//input[@value='Update']";
        private readonly By UpdateEditDocumentFormButtonLocator = By.XPath(xpathUpdateEditDocumentFormButton);

        private const string xpathCancelEditDocumentFormButton = "//div[@class='edit_emp_docs_div']//button[text()='Cancel']";
        private readonly By CancelEditDocumentFormButtonLocator = By.XPath(xpathCancelEditDocumentFormButton);

        #endregion

        #region Delete Document Popup Window Element

        private const string xpathDeleteDocumentPopupWindow = "//div[@id='popup_container']";
        private readonly By DeleteDocumentPopupWindowLocator = By.XPath(xpathDeleteDocumentPopupWindow);

        private const string xpathDeleteDocumentPopupTitle = "//h1[@id = 'popup_title']";
        private readonly By DeleteDocumentPopupTitleLocator = By.XPath(xpathDeleteDocumentPopupTitle);

        private const string xpathMessageOfDeleteDocumentPopupWindow = "//div[@id='popup_message']";
        private readonly By MessageOfDeleteDocumentPopupWindowLocator = By.XPath(xpathMessageOfDeleteDocumentPopupWindow);

        private const string xpathOKButtonOfDeleteDocumentPopupWindow = "//input[@id = 'popup_ok']";
        private readonly By OKButtonOfDeleteDocumentPopupWindowLocator = By.XPath(xpathOKButtonOfDeleteDocumentPopupWindow);

        private const string xpathCancelButtonOfDeleteDocumentPopupWindow = "//input[@id = 'popup_cancel']";
        private readonly By CancelButtonOfDeleteDocumentPopupWindowLocator = By.XPath(xpathCancelButtonOfDeleteDocumentPopupWindow);

        #endregion

        #endregion
    }
}
