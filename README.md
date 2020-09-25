<H1>JSON Web Token(JWT) Authentication in .NET core 3.1 and Angular 8+.</H!>
<br>
<h3>You can clone the Project in your local machine</h3>
<br>
<h4>For frontend setup</h4>
<p> Move to JWTAuthFrontend and run command "npm i"</p>
<p>then you can run the project using command "ng serve -o"</p>
<br>
<h4>For backend setup</h4>
<p>Move to JWTAuth Folder</p>
<p>You have to delete the migration Folder and also change the connection string in json file.</p>
<p>Now you have to add migration using the command "dotnet ef migrations add 'Migration Name'"</p>
<p>then you will see migrations folder in your project</p>
<p>Now to connect database run command "dotnet ef update database"</p>
<p>In your SQL Server new Database will be created with the name provided at the time of adding connection String</p>
<p>now you can run your project using command "dotnet run"</p>
<p>and that's all. you will be able to see your project up and running without any error.</p>

  
