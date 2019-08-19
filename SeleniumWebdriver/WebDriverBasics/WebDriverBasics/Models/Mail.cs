namespace WebDriverBasics
{
    class Mail
    {
        private string _address;
        private string _subject;
        private string _text;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public Mail(string address, string subject, string text)
        {
            Address = address;
            Subject = subject;
            Text = text;
        }
    }
}
