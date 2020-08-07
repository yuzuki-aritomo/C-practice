#include<stdio.h>

struct Person {
	char name[40];
	int height;
	float weight;
};

int main(void) {
	struct Person p;
	
	scanf("%s", &p.name);
	scanf("%d", &p.height);
	scanf("%f", &p.weight);

	float heightkg= (float)p.height / 100;

	printf("%s \n", p.name);
	printf("%f \n", p.weight/heightkg/heightkg);

	return 0;
}

