#include <iostream>
#include "Numer.h"
namespace usr 
{
	double RootFinding(double(*f)(double), double x, double eps) 
	{
		double slope, f_val;
		
		for (int i = 0; i <= 100; i++) {
			f_val = (*f)(x);
			if (abs(f_val) <= eps) {
				std::cout << "# of loop in Newton method = " << i << "\n";
				break;
			}

			slope = ((*f)(x + eps) - f_val) / eps;
			x = x - f_val / slope;

		}
		return x;
	}

}

