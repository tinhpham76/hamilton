#include <iostream>

#include <conio.h>
#define max 20

int a[max][max];
int b[max], c[max];
int n;

void init()
{
    FILE *f = fopen("CCHMTON.IN", "r");
    fscanf(f, "%d", &n);
    for (int k = 0; k < n; k++)
        for (int j = 0; j < n; j++)
            fscanf(f, "%d", &a[k][j]);
    for (int k = 0; k < n; k++)
        b[k] = 0;
    c[0] = 0;
    b[0] = 1; // Xuất phát từ đỉnh 0
}

void showpath()
{
    for (int k = 0; k < n; k++)
        printf("%4d", c[k] + 1); //In ra số hiệu đỉnh+1
    printf("%4d\n", c[0] + 1);
}
void Hamilton(int j)
{
    for (int k = 0; k < n; k++)
        if (b[k] == 0 && a[c[j - 1]][k])
        {
            b[k] = 1;
            c[j] = k;
            if (j == n - 1)
            {
                if (a[c[j]][c[0]])
                    showpath();
            }
            else
                Hamilton(j + 1);
            b[k] = 0;
        }
}

int main()
{
    init();
    Hamilton(3);
    return 1;
}