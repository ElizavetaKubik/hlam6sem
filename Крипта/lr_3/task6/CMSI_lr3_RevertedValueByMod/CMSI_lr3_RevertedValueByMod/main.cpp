#include <iostream>
using namespace std;
#define isEven(x) ( (x & 0x01) == 0)
# define isOdd(x) (x & 0x01)
# define swap(x,y) (x^= y, y^= x, x^= y)
void ExtBinEuclid(int* u, int* v, int* ul, int* u2, int* u3) {
	int k, tl, t2, t3;
	if (*u < *v) swap(*u, *v);
	for (k = 0; isEven(*u) && isEven(*v); ++k) {
		*u >>= 1; *v >>= 1;
	}
	*ul = 1; *u2 = 0; *u3 = *u; tl = *v; t2 = *u - 1; t3 = *v;
	do {
		do {
			if (isEven(*u3)) {
				if (isOdd(*ul) || isOdd(*u2)) {
					*ul += *v; *u2 += *u;
				}
				*ul >>= 1; *u2 >>= 1; *u3 >>= 1;
			}
			if (isEven(t3) || *u3 < t3) {
				swap(*ul, tl); swap(*u2, t2); swap(*u3, t3);
			}
		} while (isEven(*u3));
		while (*ul < tl || *u2 < t2) {
			*ul += *v; *u2 += *u;
		}
		*ul -= tl; *u2 -= t2; *u3 -= t3;
	} while (t3 > 0);
	while (*ul >= *v && *u2 >= *u) {
		*ul -= *v; *u2 -= *u;
	}
	*ul <<= k; *u2 <<= k; *u3 <<= k;
}

int main(int argc, char** argv) 
{
	int a, b, gcd;
	if (argc < 3) 
	{
		cerr << "Using: xeuclid u v" << endl;
		return -1;
	}
	int u = atoi(argv[1]);
	int v = atoi(argv[2]);
	if (u <= 0 || v <= 0) 
	{
		cerr << "Argumentes should be positive! " << endl;
		return -2;
	}
	ExtBinEuclid(&u, &v, &a, &b, &gcd);
	cout << a << " * " << u << " + (-"
		<< b << ") * << " << v << " = " << gcd << endl;
	if (gcd == 1)
		cout << "Reverted value " << v << " mod " << u << " equal " << u - b << endl;
	return 0;
}