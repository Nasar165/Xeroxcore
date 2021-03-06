# Unit Testing Coding Guideline

### Intro

Unit testing is a critical component to the success of the project. Unit testing keeps
the framework maintainable and less prone to bugs and unforeseen exceptions. To simplify
the process of writing a unit test we at MCS has introduced a set of rules. Making it easy
for us all involved to read and examine the test and if needed adjust a test to make it
more reliable.

### .Net Core Command Line

This section explains how to generate a unit test utilizing a .Net Core with a command line.
wich test to use depends entirely to you. We recommend that you use Xunit for testing
Controllers while using MS Unit test for testing components.

MS Unit Test

```
Make sure that you are in the main directory before running any of the following.
1. dotnet new mstest -o <foldername>
2. dotnet add reference <path to project to test>

Sample
Make sure that you are in the main directory before running any of the following.
1. dotnet new mstest -o /test/api.test
2. cd /test/api.test
3. dotnet add reference ../../src/api
You will now have access to the API's functionality
```

Xunit

```
Make sure that you are in the main directory before running any of the following.
1. dotnet new xunit - o <foldername>
2. dotnet add reference <path to project to test>

Sample
Make sure that you are in the main directory before running any of the following.
1. dotnet new xunit -o /test/api.test
2. cd /test/api.test
3. dotnet add reference ../../src/api
You will now have access to the API's functionality
```

### Comments

A developer committing code must only apply comments if necessary. Mainly because of comments
might become outdated, confusing other developers trying to improve an already existing test.
To combat comments please choose good variable, method and class names instead of adding
comments.

## Unit test Class and method structure

### Sample

```csharp
namespace mcs.components.test
{
    [TestClass]
    public class AesEncryptionTest
    {
        public AesEncryptionTest()
        {
            AesEncrypter._instance = new AesEncrypter("b14ca5898a4e4133bbce2ea2315a1916");
        }

        [TestMethod]
        public void EncryptData()
        {
           var unEncryptedText = "Nasar is the greatest";
           var encryptedText = AesEncrypter._instance.EncryptData(unEncryptedText);
           Assert.AreNotEqual(unEncryptedText,encryptedText);
        }

        [TestMethod]
        public void DecryptData()
        {
            var unEncryptedText = "Nasar is the greatest";
            var encryptedText = AesEncrypter._instance.EncryptData(unEncryptedText);
            var decryptedText = AesEncrypter._instance.DecryptyData(encryptedText);
            Assert.AreEqual(unEncryptedText,decryptedText);
        }
    }
}

```

## Type of tests

There are many ways to test a method, in this case, we might test that a method is working
as intended called a positive test where we predict a positive outcome. Or we might perform
a negative test where we intentionally attempt to break a method by inserting incorrect values.
Negative Test helps us to find bugs within our code making the framework more stable.

### MS Unit Test

#### Positive tests

A positive test aims at testing a method or class that it functions as intended. The test's
the main focus is to provide a positive result showing that all is working as it should be given
that all the inputs are correct.

##### Sample

```csharp
[TestMethod]
public void EncryptData()
{
   var unEncryptedText = "Nasar is the greatest";
   var encryptedText = AesEncrypter._instance.EncryptData(unEncryptedText);
   Assert.AreNotEqual(unEncryptedText,encryptedText);
}
```

#### Negative Tests

Negative tests your class or method for faults, it's designed to break your code. This is
helpful when trying to identify bugs within your code and what better way than to break it
yourself. So a successful negative test is where your code breaks and won't give the expected
result.

##### Sample

```csharp
[TestMethod]
public void EncryptNullvalue()
{
   try
   {
      var encryptedText = AesEncrypter._instance.EncryptData(null);
   }
   Catch(Exception error)
   {
      Assert.AreEqual("The parsed value can not be null",error.message);
   }
}
```

## Xunit Test Controllers

Xunit is great for testing your controllers to make sure that they work as intended. API
controllers test are important to make sure that the API is working as intended improving
the overall quality and integrity of the API.

### Sample Positive test

```csharp
public class AuthenticationTest : IClassFixture<WebApplicationFactory<api.Startup>>
{
        private readonly WebApplicationFactory<api.Startup> WebApp;
        public AuthenticationTest(WebApplicationFactory<api.Startup> webapp)
            => WebApp = webapp;

        private StringContent CreateJsonContent(string data)
            => new StringContent(data, Encoding.UTF8, "application/json");

        [Theory]
        [InlineData("/apiauth")]
        public async void APIAuthControllerTest(string url)
        {
            var client = WebApp.CreateClient();
            var response = await client.PostAsync(url,
            CreateJsonContent("{\"TokenKey\":\"#we321$$awe\", \"GroupKey\":\"12\"}"));
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
  }
```

### Sample Negative test

```csharp
public class AuthenticationTest : IClassFixture<WebApplicationFactory<api.Startup>>
{
        private readonly WebApplicationFactory<api.Startup> WebApp;
        public AuthenticationTest(WebApplicationFactory<api.Startup> webapp)
            => WebApp = webapp;

        private StringContent CreateJsonContent(string data)
            => new StringContent(data, Encoding.UTF8, "application/json");

        [Theory]
        [InlineData("/apiauth")]
        public async void APIAuthControllerNegativeTestBadRequest(string url)
        {
            var client = WebApp.CreateClient();
            var response = await client.PostAsync(url,
            CreateJsonContent("{\"TokenKeys\":\"#we321$$awe\", \"GroupKeys\":\"12\"}"));
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
  }
```
