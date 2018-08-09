# Calculator

Welcome to calculator!

        With a desktop application, you can perform simple arithmetic operations

        If you did not receive an answer immediately, do not worry, we will send it to you by email

## Launch application

To run the application in visual studio, set the solution startup project as a "Multiple Startup Project" and select Calculator.Web.Services.proj and Calculator.Ui.Wpf.proj.


##Unit Tests

To run unit tests just right button click on solution and pick "Run Unit Tests" (ReSharper needed)

##DB

To create db, run scripts: 01CreateDbScript.sql, 02CreateTables.sql, 03CreateLoginUser.sql

##Configuration

To change db connection string use calc.config in section         <db>
    <sql connectionString="Max Pool Size=400;Connection Timeout=120;Data Source=localhost;Initial Catalog=Calculator;Persist Security Info=True;user id=calculator;password=1!password;" />
 </db>

To change calculator id use calc.config in section
  <app calculatorId="123" />

To change the pending queue scan period use calc.config in section  <watcher checkingPeriodInMs="10000" />
