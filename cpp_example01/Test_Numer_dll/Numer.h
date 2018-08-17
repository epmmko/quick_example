#pragma once
namespace usr {
	__declspec(dllexport) double RootFinding(double(*f)(double),
		double x = 4, double eps = 1e-8);
	/*
	Use Newton method to solve equation f(x) = 0
	1st argument: pointer to a function f
	2nd argument: initial guess
	3rd argument: epsilon value for derivative calculation and exit condition
	*/
}
