# SendGrid Contacts API Test (C#)

##Announcement##
Now there is a [v3 Beta branch](https://github.com/sendgrid/sendgrid-csharp/tree/v3beta) of official library, which contains implementation for 
endpoints other than Send Mail. So if you want to try Contacts API, you may do so with that branch. Keep in mind, that beta branch is not for production.

##About This Project##
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