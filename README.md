# Get Started

1. Open CMD/Terminal navigate to directory you would like it to be in. Ex) cd ...

2. Git clone https://github.com/cruiser/employee_receipts.git in current directory

3. Then run "git status", "git checkout main", "git pull --rebase origin", just to make sure everything has been pulled from the repo. Usually it does it automatically.

4. run project in Rider or IDE of your choice. Navigate to current directory of project. Usually you can right click the solution and open in terminal into the exact directory

5. Then run "dotnet run"

6. if it throws a Json Error, make sure you open up the receipts.db file that will show up in your solution explorer. Double click it and hit okay. I had this issue when on windows. I created it on macbook with no issues.

7. You should now see the message "listening on: {URI}". copy and paste that into your browser of choice.

8. Use the app and enjoy!
