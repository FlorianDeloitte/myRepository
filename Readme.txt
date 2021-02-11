I am not used to .NetCore but I decided I would give it a try so it slowed me down.
I started analyzing all the best practices for authentication and caching in .NetCore and realized it would take me too much time.
I try to look for the best practices when possible
I was able to use Dependency Injection easily as it is native in .NetCore. I would have used this for mocking implementations for testing
I am aware the code is just for one user as it is. However the tasks caching would work for different users as the key of the cache is the userId.

A database is created in C:/ Change this if needed. 

To use the project : Make sure you have the rights to write in the directory the database is created in.
Login with "test" and password "pwd123". Add tasks and save.  If tasks are changed / removed / added, refresh the page to see that the previous tasks were indeed cached.
