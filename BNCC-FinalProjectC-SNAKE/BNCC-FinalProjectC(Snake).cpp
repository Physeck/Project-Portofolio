/*
2602095902 Justin Tjandra
2602097731 Julian Saputra
2602062614 Jeffrey Surianto
*/

#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<windows.h>
#include<time.h>

int height = 20, width = 60;
int score = 0, gameover = 0;
int highscore;

struct node{
   int x,y;
   char ch;
};

void gotoxy(int x, int y){ 
    COORD c;
    c.X = x;
    c.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), c);
}

void readHighscore(){
    FILE *f = fopen("highscore.txt","r");
    if (!f) { 
        printf("Error: Failed to open, creating highscore.txt file\n"); getchar();
        FILE *f = fopen("highscore.txt","wb");
    }
    fscanf(f,"%d",&highscore);
	fclose(f);
    return;
}
void writeHighscore(){
	FILE *f = fopen("highscore.txt","w+");; 
	fprintf(f,"%d",highscore);
	fclose(f);
	return;
}


void fillSnake(struct node s[],int length){ 
    for(int i=0;i<length;i++){
        s[i].ch='+'; 
        s[i].x=width/2-i;
        s[i].y=height/2;
    }
    s[0].ch='@'; 
}

void printSnake(struct node s[],int n){ 
    for(int i=0;i<n;i++){
        gotoxy(s[i].x,s[i].y);
        printf("%c",s[i].ch);
    }
}

void delSnake(struct node s[],int n){
    for(int i=0;i<n;i++){
        gotoxy(s[i].x,s[i].y);
        printf(" ");
    }
}

void moveSnake(struct node s[],int n, int dx, int dy){ 
	for (int i=n-1;i>0;i--){
		s[i].x = s[i-1].x;
    	s[i].y = s[i-1].y;
  	}
  	s[0].x+=dx;
  	s[0].y+=dy;
}

void checkIfHitBorder(struct node s[],int n){ 
    if(s[0].x<1 || s[0].x>width || s[0].y<=1 || s[0].y>height){
		gameover = 1;
		return;
	}
}

void checkIfHitTail(struct node s[], int n){ 
	for(int i=1; i<n; ++i){
		if(s[0].x==s[i].x && s[0].y==s[i].y){
			gameover = 1;
			return;
		}
	}
}

int checkIfFoodInsideSnake(struct node *food, struct node s[],int length){
	for(int i=0; i<length; ++i){
		if(food->x==s[i].x && food->y==s[i].y){
			return 1;
		}
	}
	return 0;
}

void initFood(struct node *food, struct node s[],int length){ 
	do{
		food->x=rand()%width-5;
		food->y=rand()%height-5;
	}while(food->x < 4 || food->y < 4 || checkIfFoodInsideSnake(food,s,length) == 1);
}

void printFood(struct node food){ 
    gotoxy(food.x,food.y);
    printf("O");
}

int checkEaten(struct node s[], struct node food){ 
    if(s[0].x==food.x && s[0].y==food.y)
        return 1;
    else
        return 0;
}

void initIncreaseLength(struct node s[],int n){ 
    s[n-1]=s[n-2];
}

//function for menu
int menu(){
	system("cls");
	printf("===============SNAKE===============\n");
	printf("|| Press enter to start the game!||\n");
	printf("||  Press esc to exit the game!  || \n");
	printf("===================================\n\n");
	while(1){
		if(kbhit()){
			switch(getch()){
				case 27: 
					return 0;
				case 13: 	
					return 1;
			}
		}
	}
}

void printScore(){ 
	gotoxy(0,0);
	printf("Score : %d | High Score : %d\n",score,highscore);
}

void drawBoard(){ 
    for(int i=0;i<=height+1;i++){
        for(int j=0;j<=width+1;j++){
			if(i==0){
				if(j==0){
					printf("%c",201);
				}else if(j==width+1){
					printf("%c",187);
				}else{
					printf("%c",205);
				}
			}else if(i==height+1){
				if(j==0){
					printf("%c",200);
				}else if(j==width+1){
					printf("%c",188);
				}else{
					printf("%c",205);
				}
			}else if (j==0 || j==width+1 ){
				printf("%c",186);
			}else printf(" ");
        }
        printf("\n");
    }
    printf("\nPress Up, Left, Right or Down Arrow key for control\n\n");
    printf("Press [esc] to quit the game!\n");
}

int main(){
	readHighscore();
	if(menu()){
		start:
			struct node food;
			struct node snake[100];
			int length = 4;
			int dx = 1, dy = 0;
			char key;
			score = 0;
			gameover = 0;
			srand(time(NULL));
			system("cls");
			printScore();
			drawBoard();
			initFood(&food,snake,length);
			fillSnake(snake,length);
			do{
				printFood(food);
				printSnake(snake,length);
				Sleep(100);
				delSnake(snake,length);
				moveSnake(snake,length,dx,dy);
				checkIfHitBorder(snake, length);
				checkIfHitTail(snake,length);
				if(gameover==1){
					gotoxy(0,height+6);
					
					do{
						printf("You crossed the border! Do you want to restart?(y/Y | n/N): ");
						scanf("%c",&key); getchar();
						if(key=='y' || key=='Y'){
							goto start;
						}else if (key == 'n' || key =='N'){
							printf("You exited the game!\n"); getchar();
							writeHighscore();
							return 0;
						}
					}while(key != 'y' || key != 'Y' || key !='n' || key != 'N');
				}
				if(checkEaten(snake,food)){
					initFood(&food,snake,length);
					score+=1;
					if(highscore<score) highscore = score;
					printScore();
					length++;
					initIncreaseLength(snake,length);
				}
				if(kbhit()){
					key=getch();
					switch(key){
						case 72:if(dy!=1){dx=0;dy=-1;}break;
						case 80:if(dy!=-1){dx=0;dy=1;}break;
						case 77:if(dx!=-1){dx=1;dy=0;}break;
						case 75:if(dx!=1){dx=-1;dy=0;}break;
					}
				}
				
  			}while(key!=27);
	}else{
		return 0;
	}
}
