# ReCapProject (based on Car Rental) Önder ALKAN

This project aims to show the methods and techniques used when developing a N-Tier architecture application. 

## Abilities
Project has ability to work with **AOP (Aspect Oriented Programming), Data Validation (FluentValidation)** and layer based **Dependency Injection Resolver**. 

Dependencies section will explain the packages.

## Architecture
Project has N-Tier (or multilayered) architecture such as 

 - **Business Layer**
 - **Data Access Layer**
 - **Presentation Layer**
 - **Entities (helper layer for models)**
 - **Core Layer (non-dependant to the other layers)**

**Core Layer** handles the early developing period by itself, it coded before and no need to write CRUD methods again. This is accomplished by implementing a generic repository for all contexts and entities.

## Dependencies
Project dependant on several NuGet packages, Such as:

 - **Autofac**
 - **Autofac.Extensions.DependencyInjection**
 - **Autofac.Extras.DynamicProxy**
 - **FluentValidation**
 - **Microsoft.AspNetCore.Http.Features**
 - **Microsoft.EntityFrameworkCore.Design**
 - **Microsoft.EntityFrameworkCore.SqlServer**
 - **NETStandard.Library**
 - **System.ComponentModel.Annotations**

For further questions please email me [here](mailto:onder.alkan15@gmail.com)
Visit my LinkedIn Profile [here](https://www.linkedin.com/in/alkanonder/)
