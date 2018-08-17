#include <iostream>
#include "Numer.h"
using namespace std;

double f1(double x)
{
	return pow(x, 2) - 4.7 * x + 4.8;
}

int main()
{
	double ans;
	 
	ans = usr::RootFinding(f1,-1);
	cout << ans << '\n';
	system("pause");
}