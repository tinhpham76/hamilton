#include <iostream>

#include <conio.h>

using namespace std;

#define MAX 50

#define TRUE 1

#define FALSE 0

int A[MAX][MAX]; //ma trận kề của đồ thị.

int C[MAX], B[MAX]; //mảng đánh dấu.

int n; //số đỉnh của đồ thị.

int d; //đếm số đường đi Hamilton.

void Init(void)
{

    freopen("DDHMTON.IN", "r", stdin);

    cin >> n;

    //nhập ma trận liền kề.

    for (int i = 1; i <= n; i++)
    {

        for (int j = 1; j <= n; j++)
        {

            cin >> A[i][j];
        }
    }

    for (int i = 1; i <= n; i++)

        C[i] = 0;
}

void Result(void)
{

    cout << "Duong di Hamilton: ";

    for (int i = n; i > 0; i--)

        cout << B[i] << " ";

    d++;

    cout << endl;
}

void Hamilton(int *B, int *C, int i)
{

    int j, k;

    for (j = 1; j <= n; j++)
    {

        if (A[B[i - 1]][j] == 1 && C[j] == 0)
        {

            B[i] = j;
            C[j] = 1;

            if (i < n)
                Hamilton(B, C, i + 1);

            else
                Result();

            C[j] = 0;
        }
    }
}

int main()
{

    B[0] = 1;

    int i = 1;

    d = 0;

    Init();

    Hamilton(B, C, i);

    if (d == 0)

        cout << "Khong co duong di Hamilton";

    getch();
}