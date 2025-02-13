#include <iostream>
using namespace std;
#include <mysql.h> // these libraries were added by including folders to project options
#include <mysqld_error.h> // and this particularly, when posting the ".dll" to the project fonder.
char HOST[] = "localhost";
char USER[] = "dbuser";
char PASS[] = "dbpass";	//you data to log in
									// These are not necessary, but useful.
int main() {
	MYSQL* obj;
	int Collage_ID;
	char Name[20];
	char BirthDate[11]; //This is always 11: YYYY-MM-DD + 0 from every char array
	float Grade;
	bool ProgramIsOpened = true;
	int answer;			// These are to keep the program opened
	char* consult;
	char* sentence;
	string sentence_aux; // These are to add data to the table.
// |-----------------|
// | 	CONNECTION	 |
	if (!(obj = mysql_init(0))){
		cout <<	"ERROR: MySQL object coud not be created." << endl;
	}
	else {
		if (!mysql_real_connect(obj, HOST, USER, PASS, "test", 3306, NULL, 0)){
			cout << "ERROR: Some database info is wrong or do not exist." << endl;
			cout << mysql_error(obj) << endl;
		}
		else {
			cout << "Logged in." << endl << endl;
			while (ProgramIsOpened){
				cout << "Collage ID: ";
				cin >> Collage_ID;
				cin.ignore(100, '\n'); //Remember to clean your buffer after using cin for int, float and double.
				cout << "Name: ";
				cin.getline(Name, 20, '\n'); //We don't use "cin >> Name " because it doesn't read spaces.
				cout << "BirthDate: ";
				cin.getline(BirthDate, 11, '\n');
				cout << "Grade: ";
				cin >> Grade;
				cin.ignore(100, '\n');
				cout << endl;
				// setting our update.
				sentence_aux = "INSERT INTO STUDENT(Collage_ID, Name, BirthDate, Grade) VALUES ('%d', '%s', '%s', '%f')";
				sentence = new char[sentence_aux.length()+1];
				strcpy(sentence, sentence_aux.c_str()); // we copy aur string statement into a *char.
				consult = new char[strlen(sentence)+sizeof(int)+strlen(Name)+strlen(BirthDate)+sizeof(float)];
				sprintf(consult, sentence, Collage_ID, Name, BirthDate, Grade); // substitutes %d.. for actulr values.
				if(mysql_ping(obj)){
					cout << "ERROR: Imposible to connect" << endl;
					cout << mysql_error(obj) << endl;
					}
				if (mysql_query(obj, consult)){
					cout << "ERROR: " << mysql_error(obj) << endl;
					rewind(stdin);
					getchar();
 					}
 					else {
 						cout << "Info added correctly." << endl;
 					 	}
 				mysql_store_result(obj);
 				cout << endl << "Another?" << endl;
 				cout << "[1]: Yes" << endl;
				cout << "[0]: No" << endl;
				cout << "answer: ";
				cin >> answer;
				cin.ignore(100, '\n');
				if (answer == 0){
					ProgramIsOpened = false;
					}
				cout << endl;
			}		
		}
	}
	cout << "BYE!" << endl;
	return 0;
}
