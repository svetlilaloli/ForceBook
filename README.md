Console Application<br/>
Exercise: Associative Arrays

# ForceBook
The force users are struggling to remember which side are the different forceUsers from, because they switch them too often. So you are tasked to create a web application to manage their profiles. You should store an information for every __unique forceUser__, registered in the application.<br/>
You will receive __several input lines__ in one of the following formats:<br/><br/>
__{forceSide} | {forceUser}__<br/>
__{forceUser} -> {forceSide}__<br/><br/>
The __forceUser__ and __forceSide__ are strings, containing any character. <br/>
If you receive __forceSide | forceUser__, you should __check if such forceUser already exists__, and __if not, add__ him/her to the corresponding side. <br/>
If you receive a __forceUser -> forceSide__, you should check if there is such a __forceUser already__ and if so, __change his/her side__. If there is __no such forceUser, add__ him/her to the corresponding forceSide, treating the command as a __new registered forceUser__.<br/><br/>
__Then you should print on the console: "{forceUser} joins the {forceSide} side!__"<br/><br/> 
You should end your program when you receive the command __"Lumpawaroo"__. At that point you should print each force side, __ordered descending by forceUsers count, than ordered by name__. For each side print the __forceUsers, ordered by name__.<br/>
In case there are __no forceUsers in a side__, you should __not print__ the side information. 
## Input / Constraints
* The input comes in the form of commands in one of the formats specified above.
* The input ends, when you receive the command __"Lumpawaroo"__.
## Output
* As output for each forceSide, __ordered descending by forceUsers count, then by name__, you must print all the forceUsers, __ordered by name alphabetically__.
* The output format is:<br/>
__Side: {forceSide}, Members: {forceUsers.Count}<br/>
! {forceUser}<br/>
! {forceUser}<br/>
! {forceUser}__
* In case there are __NO forceUsers__, don't print this side. 
## Examples
Input|Output|Comments
-----|------|--------
Light \| John<br/>Dark \| Peter<br/>Lumpawaroo|Side: Dark, Members: 1<br/>! Peter<br/>Side: Light, Members: 1<br/>! John|We register John in the Light side<br/> and Peter in the Dark side. After receiving "Lumpawaroo"<br/> we print both sides, ordered by<br/> membersCount and then by name.
Lighter \| Royal<br/>Darker \| DCay<br/>John Smith -> Lighter<br/>DCay -> Lighter<br/>Lumpawaroo|John Smith joins the Lighter side!<br/>DCay joins the Lighter side!<br/>Side: Lighter, Members: 3<br/>! DCay<br/>! John Smith<br/>! Royal|Although John Smith doesn't have profile,<br/> we __register__ him and add him to the Lighter side.<br/>We __remove DCay__ from Darker side<br/> and add him to Lighter side.<br/>We print only Lighter side because<br/> Darker side __has no members__.
