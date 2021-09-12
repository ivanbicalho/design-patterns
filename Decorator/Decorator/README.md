# Decorator

---

## Definition

Attaches additional responsibilities to an object dynamically.

## Diagram

![decorator](decorator.png)

## Real example

The code shows a repository CustomerRepository that implements ICustomerRepository interface. This repository go to the database to get data.

Our goal is to add cache when getting the customer. Commonly, we should change the CustomerRepository implementation for achieve it, but with decorator it's not necessary.

We just created a new cached implementation that receives a CustomerRepository object and implements the cache, without changes the CustomerRepository class.