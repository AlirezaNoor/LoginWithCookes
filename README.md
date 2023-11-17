# LoginWithCookes

Logging in with cookies is a common authentication method in web applications. It involves the use of HTTP cookies to store user authentication information. Here's an explanation of the process:

Authentication Process:

When a user enters their credentials (usually a username and password) and submits them, the server validates the information.
If the credentials are valid, the server creates a session for the user.
Cookie Creation:

To maintain the user's authenticated state, the server sends an HTTP response to the browser with a Set-Cookie header.
The Set-Cookie header contains information such as the cookie name, value, expiration date, domain, path, and other optional attributes.
Cookie Storage:

The browser stores the received cookie on the user's device. Subsequent requests to the same domain include this cookie in the HTTP header automatically.
Session Maintenance:

With each request, the server checks the received cookie to identify the user's session.
If the cookie is valid and matches an existing session, the user is considered authenticated.
Logout and Expiry:

To end a user's session, the server can invalidate the cookie by setting its expiration date in the past or by clearing it on the client side.
Users can manually log out, and the server can also implement additional security measures such as checking for inactivity and automatically logging out users.
Secure Attributes:

Cookies used for authentication should have secure attributes, such as being marked as "HttpOnly" to prevent access by client-side scripts and "Secure" to ensure they are only sent over HTTPS connections.
Here's a simple example in ASP.NET Core without using Identity. This example sets a cookie upon successful authentication and checks for the cookie on subsequent requests:
