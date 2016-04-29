# SendGrid Contacts API Test (C#)

[C# Library](https://github.com/sendgrid/sendgrid-csharp) is good for sending transactional emails
but SendGrid Web API has many more RESTful endpoints than Mail Send.

I needed to add a contact (recipients under Contacts
API as they are called in SendGrid world) when webpage visitor accepts newsletter membership.

Although messy, this example project might give you an idea how it is done simply with HttpClient.
You may need to read [Docs for Contacts API](https://sendgrid.com/docs/API_Reference/Web_API_v3/Marketing_Campaigns/contactdb.html) to understand what's going on
if you haven't already.

Don't forget to put your API KEY in Program.cs instead of dummy string.

###WARNING
SendGrid warns developers not to use Contacts API to add email addresses without owners' consent, so I'd like 
to repeat that as well.