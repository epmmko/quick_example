# quick_example
for a quick c++ code lookup

## create dll and call from cpp file example: call a function that take one function as an input
In this example, a step-by-step precedure to create a library and call from c++ by linking implicitly is shown.
I learned this from MSDN
https://docs.microsoft.com/en-us/cpp/build/walkthrough-creating-and-using-a-dynamic-link-library-cpp
and youtube https://www.youtube.com/watch?v=r-DMGvSHFuU

- Step 1: create header for dll file (just a function prototype)
<br>.\UserMathDll\Numer.h and .\UserMathDll\Numer_dll.cpp
<br>Use `__declspec(dllexport)` in the header so that the function in dll can be called
- Step 2: create dll (in .cpp) and build solution together with the header file
<br>Give the function definition here (include the header file first).
<br>In this example, the function `RootFinding` is created. It take a function (that take 1 double) as an input together with the initial value and the epsilon value used in Newton-Rhapson method for estimating the slope and exit condition. I note that the main function is called just twice in each for-loop to calculate the function value at x and x+epsilon.
- Step 3: select release mode in Visual studio and build solution to get .lib and .dll files.
- Step 4: create the main cpp file to call a function from the library (dll). Include the header file at the top
<br> right click on the <b>Header Files</b> in the <b>Solution Explorer</b> and select .h file created previously to allow Visual Studio to locate the header file.
- Step 5: copy .lib and .dll file from `.\UserMathDll` to `Test_Numer_dll`
- Step 6: allow Visual Studio to locate the `dll` file by right-click at the `call to dll` project, select `properties` -> `Linker` -> `Input` -> edit `Additional Dependencies` -> then type `UserMathDll.lib` (or whatever .lib that was created in the release folder when build solution for the dll project). The specific steps are shown in MSDN (the link above), too. Then run the program

It is quite clumsy to close the `dll` project and create a new project to test `dll` file. One way to do this quick is to add `New Project...` into the solution explorer so that both `dll` and `call to dll` can be seen at once.
<br>By doing so, a correct startup procedure is needed. This setting was done by right-click on the main `Solution` in the solution explorer and click on `Properties` -> `Common Properties` -> `Startup Project` and set to do the `Single startup project` on `call to dll` main() program. Without properly setting the `Startup Project` and have 2 project in 1 solution, the error like `.dll is not a valid Win32 application` can occur, because the IDE try to start the program by calling .dll directly, instead of calling the int main().

I hope this help, at least should help me in future when I forget all about this.
