using System;
using NUnit.Framework;

namespace WebDriverBasics
{
    [TestFixture]
    class Tests : BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            var yandexMainPage = LoginPage.LoginAs(testUser);
            Assert.IsTrue(yandexMainPage.SendLetterButton.Displayed);
        }

        [Test]
        public void VerifyThatMailIPresentedInDraftFolder()
        {
            var yandexMainPage = LoginPage.LoginAs(testUser);
            yandexMainPage.ShowDrafts();
            int initialDraftCount = yandexMainPage.GetLettersFromFolder().Count;
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(testMail);
            yandexMainPage.ShowDrafts();
            int finalDraftCount = yandexMainPage.GetLettersFromFolder().Count;

            Assert.AreEqual(finalDraftCount, initialDraftCount + 1);
        }

        [Test]
        public void VerifyDraftAddress()
        {
            var yandexMainPage = LoginPage.LoginAs(testUser);
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(testMail);
            yandexMainPage.ShowDrafts();
            yandexSendMessagePage = yandexMainPage.OpenLatestLetter();
            var actualDraftAddress = yandexSendMessagePage.AddressField.Text;
            Console.WriteLine(actualDraftAddress);

            Assert.AreEqual(testMail.Address, actualDraftAddress);
        }

        [Test]
        public void VerifyDraftSubject()
        {
            var yandexMainPage = LoginPage.LoginAs(testUser);
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(testMail);
            yandexMainPage.ShowDrafts();
            yandexSendMessagePage = yandexMainPage.OpenLatestLetter();
            var actualDraftSubject = yandexSendMessagePage.SubjectField;

            Assert.AreEqual(testMail.Subject, actualDraftSubject.GetAttribute("value"));
        }

        [Test]
        public void VerifyDraftText()
        {
            var yandexMainPage = LoginPage.LoginAs(testUser);
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(testMail);
            yandexMainPage.ShowDrafts();
            yandexSendMessagePage = yandexMainPage.OpenLatestLetter();
            var actualDraftText = yandexSendMessagePage.TextField.Text;

            Assert.AreEqual(testMail.Text, actualDraftText);
        }

        [Test]
        public void VerifyThatMailIsPresentedInSendedMailsFolder()
        {
            var yandexMainPage = LoginPage.LoginAs(testUser);
            yandexMainPage.ShowSendedLetters();
            int initialSentMailsCount = yandexMainPage.GetLettersFromFolder().Count;
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(testMail);
            yandexMainPage.ShowDrafts();
            yandexSendMessagePage = yandexMainPage.OpenLatestLetter();
            yandexMainPage = yandexSendMessagePage.ClickSendLetterButton();
            yandexMainPage.ShowSendedLetters();
            int finalMailsCount = yandexMainPage.GetLettersFromFolder().Count;

            Assert.AreEqual(finalMailsCount, initialSentMailsCount + 1);
        }

        [Test]
        public void VerifyThatMailIsNotPresentedInDraftFolderAfterSanding()
        {
            var yandexMainPage = LoginPage.LoginAs(testUser);
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(testMail);
            yandexMainPage.ShowDrafts();
            int initialDraftCount = yandexMainPage.GetLettersFromFolder().Count;
            yandexSendMessagePage = yandexMainPage.OpenLatestLetter();
            yandexMainPage = yandexSendMessagePage.ClickSendLetterButton();
            yandexMainPage.ShowDrafts();
            int finalDraftCount = yandexMainPage.GetLettersFromFolder().Count;

            Assert.AreEqual(finalDraftCount, initialDraftCount - 1);
        }
    }
}
