# customer-transactions
A simple asp.net web api to solve a simple task.  
The api simply returns data on customers and their transactions with no authentication requied.  
You can query a customer and it's 5 latest transactions by providing either the Customer ID, the e-mail or both.

## Examples

#### Providing only the Customer ID: `api/customer/<CustomerID>` or `api/customer?id=<CustomerID>`
`api/customer?id=1`
```
{"customerID":1,"email":"number1@gmail.com","name":"No Transactions","mobile":"012345678","transactions":[]}
```

#### Providing only the e-mail: `api/customer?email=<Email>`
`api/customer?email=number2@gmail.com`
```
{"customerID":2,"email":"number2@gmail.com","name":"One Transaction","mobile":"012345678","transactions":[{"id":1,"date":"20-05-19 19:29","amount":"1.234,56","currency":"USD","status":"Success"}]}
```

#### Providing both the Customer ID and the matching e-mail: `api/customer?id=<CustomerID>&email=<Email>`
`api/customer?id=4&email=number4@gmail.com`
```
{"customerID":4,"email":"number4@gmail.com","name":"More than 5 Tranactions","mobile":"012345678","transactions":[{"id":5,"date":"20-05-19 19:29","amount":"1.234,56","currency":"USD","status":"Success"},{"id":6,"date":"20-05-19 19:29","amount":"1.234,56","currency":"USD","status":"Success"},{"id":7,"date":"20-05-19 19:29","amount":"1.234,56","currency":"USD","status":"Success"},{"id":8,"date":"20-05-19 19:29","amount":"1.234,56","currency":"USD","status":"Success"},{"id":9,"date":"20-05-19 19:29","amount":"1.234,56","currency":"USD","status":"Success"}]}
```
