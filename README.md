### API Response 

A simple elegant library to handle returning responses from Mediator handlers back to REST API handlers.

Often when developing public or internal REST API's it's best to define a standard structure and format of your response objects. The primary reason behind this is two fold, the most important being that you want to simplify the cognitive load required for users to become familiar and use your API.  Secondly, it will be easier for your developers to implement various API calls, because they know exactly what is required and they then only have to focus on the business logic implementation.

When implementing a Vertical Slice Architecture and REPR pattern and relying on a Mediatr or another Mediator pattern implmentation pattern you will often need to inform your REST Endpoint of whether a handler action was successful or not and also include sanitised error information to the client.


