### API Response

Often when developing public or even internal facing REST API's it's best to define a standard structure and format of your response objects. The primary reason behind this is two fold really, the most important being that you want to simply as much possible the cognitive load required for users to become familiar and use your API.  Secondly, it will be easier for your developers to implement various API calls, because they know exactly what is required and they then only have to focus on the business logic implementation.

One of the difficult aspects of developing REST based API's is that in a lot of cases there are no hard and fast standards other than REST standards, features, principles, best practices and expectations.

### REST Features
* **Stateless by nature** - every request-response is not aware of what happened previous request-response cycles.
* **HTTP protocol** - interact with HTTP requests with all HTTP verbs and generate an HTTP response.

### HTTP Verbs
* **GET** - *fetches/queries* the resource from the server and sends it back as a response. The response can be either a Simple or Complex object in either JSON or XML format.
* **POST** - *Creates* a resource on the server. Typically used for INSERT operations. The response is typically an object that was created on the server.
* **PUT** - *Updates* the object as a whole on the server. It is used for UPDATE operations.
* **PATCH** - *Updates* individual properties of the object on the server. Used for UPDATE operations on specific properties of the object and at situations where the whole object need not be touched. The response is the object that was updated on the server.
* **DELETE** - *Deletes* the object from the server. It is used for DELETE operations. The response of the object that was deleted from the server.

### REST API best practices
One of the best documents I've read on REST API best practices is the [PayPal API Design Patterns and Use Cases](https://github.com/paypal/api-standards/blob/master/patterns.md "API Design Patterns And Use Cases").  It is well worth taking the time to completely read through this document, I found it really useful and refer back to it fairly frequently when designing API's.

### Response standards
A key area I have been thinking about quite a bit, is defining a few standard response formats for a REST API.  This helps to ensure all users of your API can easily understand and use the data correctly. I also wanted a standard Response model I could use in MediatR Pipeline Behaviours that could accumulate all relevant information that about the Request/Response model as it flows through the Pipeline.
