# Class Notes

## Lecture 8 : Points to remember

### Multi-Threading

You may not update UX elements from a worker thread.

`Application.Current.Dispatcher` make the ux change from worker thread to be dispatched to the main thread.

---

### Cloud Computing

The delivery of computing services - including , server , storage , databaes , networking , softwaarw , analytics , and intelligence over the internet.

Benefits:
- Cost
- Speed of development and deployment
- Scalability
- Reliability 
- Security 
- Updated software and services

<br>

---

### Types of Cloud

- **Public Cloud**: Cloud services provided over the internet to multiple users by providers like AWS, Google Cloud, or Microsoft Azure.

- **Private Cloud**: Cloud infrastructure dedicated to a single organization, offering greater control and security.

- **Hybrid Cloud**: A combination of public and private clouds, allowing data and applications to move between them.

<br>

---

### Types of Cloud Services

- **IaaS (Infrastructure as a Service)**: Provides virtual servers, storage, and networking. Users manage the operating system and applications. *Example: AWS EC2.*

- **PaaS (Platform as a Service)**: Provides a platform to develop, test, and deploy applications without managing the underlying infrastructure. *Example: Google App Engine.*

- **SaaS (Software as a Service)**: Provides ready-to-use software over the internet, usually through a web browser. *Example: Gmail, Google Docs.*

<br>

---

### Deployment Flow

- **Provision**: Set up the required infrastructure, such as servers, storage, and networks.

- **Code**: Write the application code and implement the required features.

- **Test**: Check the application for bugs, errors, and performance issues.

- **Deploy**: Release the application to the production environment so users can access it.

- **Manage**: Monitor the application, fix issues, apply updates, and maintain performance.


<br>

---

## REST API (Representational State Transfer API)

A REST API allows applications to communicate with each other over HTTP using standard methods.

- GET: Retrieve data.
- POST: Create new data.
- PUT: Update or replace existing data.
- PATCH: Partially update existing data.
- DELETE: Remove data.

Example: A weather application uses a REST API to request weather information from a server.

Key features: Stateless communication, client-server architecture, and resources identified using URLs.

<br>

---

### Home Work

- Study the code of (https://github.com/chittur/multithreading-demo)
- explore about bob starving reader/wrirer lock.
- Write a client app (using function app in azure) and put it in the cloud


<br>

---