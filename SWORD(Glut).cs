#include <gl/glew.h>
#include <gl/freeglut.h>
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>
#include <iostream>

glm::mat4 Matrix;
glm::mat4 Proj;
GLuint matloc;
GLuint vbo;
GLuint posloc;
void display() {
	glm::mat4 temp = Proj*Matrix;
	glUniformMatrix4fv(matloc, 1, GL_FALSE, glm::value_ptr(temp));
	glClear(GL_COLOR_BUFFER_BIT);
	glEnableVertexAttribArray(posloc);
	glBindBuffer(GL_ARRAY_BUFFER, vbo);
	glDrawArrays(GL_TRIANGLES, 0, 864);
	glDisableVertexAttribArray(posloc);
	glutSwapBuffers();

}

void idol() {
	Matrix = glm::rotate(Matrix, 0.001f, glm::vec3(0, 1, 0));
	//Matrix = glm::translate(Matrix, glm::vec3(0.001, 0, 0));
	//Matrix = glm::scale(Matrix, glm::vec3(0.999));
	glutPostRedisplay();

}

int main(int arge, char**argv)
{
	glutInit(&arge, argv);
	glutInitWindowSize(512, 512);
	glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH);
	glutCreateWindow(argv[0]);
	glClearColor(0, 0, 0, 1);
	Matrix = glm::mat4(1);

	glewInit();
	glGenBuffers(1, &vbo);
	glBindBuffer(GL_ARRAY_BUFFER, vbo);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	GLuint program = glCreateProgram();

	GLuint vs = glCreateShader(GL_VERTEX_SHADER);
	GLuint fs = glCreateShader(GL_FRAGMENT_SHADER);

	Proj = glm::perspective(35.0f, 1.0f, 0.1f, 100.0f);

	Matrix = glm::lookAt(glm::vec3( 1), glm::vec3( 0 ), glm::vec3( 1, 0, 0 ) );

	float vertices[] = {
		//swordface
		//trian1
		-0.8f, 0.8f, 0.2f,    -0.5f, 0.8f,0.2f,   -0.8f, 0.5f, 0.2f,
		
		//trian2
		-0.5f, 0.5f, 0.2f,    -0.5f, 0.8f,0.2f,   -0.8f, 0.5f, 0.2f,

		//trian3
		-0.7f, 0.7f, 0.2f,    -0.4f, 0.7f,0.2f,   -0.7f, 0.4f, 0.2f,

		//trian4
		-0.4f, 0.4f, 0.2f,    -0.4f, 0.7f,0.2f,   -0.7f, 0.4f, 0.2f,

		//trian5
		-0.6f, 0.6f, 0.2f,    -0.3f, 0.6f,0.2f,   -0.6f, 0.3f, 0.2f,
		
		//trian6
		-0.3f, 0.3f, 0.2f,    -0.3f, 0.6f,0.2f,   -0.6f, 0.3f, 0.2f,

		//trian7
		-0.5f, 0.5f, 0.2f,    -0.2f, 0.5f,0.2f,   -0.5f, 0.2f, 0.2f,
		
		//trian8
		-0.2f, 0.2f, 0.2f,    -0.2f, 0.5f,0.2f,   -0.5f, 0.2f, 0.2f,

		//trian9
		-0.4f, 0.4f, 0.2f,    -0.1f, 0.4f,0.2f,   -0.4f, 0.1f, 0.2f,

		//trian10
		-0.1f, 0.1f, 0.2f,    -0.1f, 0.4f,0.2f,   -0.4f, 0.1f, 0.2f,

		//trian11
		-0.3f, 0.3f, 0.2f,     0.0f, 0.3f,0.2f,   -0.3f, 0.0f, 0.2f,

		//trian12
		 0.0f, 0.0f, 0.2f,    0.0f, 0.3f,0.2f,   -0.3f, 0.0f, 0.2f,

		//trian13
		-0.2f, 0.2f, 0.2f,    0.1f, 0.2f,0.2f,   -0.2f, -0.1f, 0.2f,

		//trian14
		0.1f, -0.1f, 0.2f,    0.1f, 0.2f,0.2f,   -0.2f, -0.1f, 0.2f,

		//trian15
		-0.1f, 0.1f, 0.2f,    0.2f, 0.1f,0.2f,   -0.1f, -0.2f, 0.2f,

		//trian16
		0.2f, -0.2f, 0.2f,    0.2f, 0.1f,0.2f,   -0.1f, -0.2f, 0.2f,

		//trian17
		0.0f, 0.0f, 0.2f,    0.4f, 0.0f,0.2f,   0.0f, -0.4f, 0.2f,

		//trian18
		0.4f, -0.4f, 0.2f,    0.4f, 0.0f,0.2f,   0.0f, -0.4f, 0.2f,

		//trian19
		-0.2f, -0.4f, 0.2f,    0.0f, -0.4f,0.2f,   -0.2f, -0.6f, 0.2f,

		//trian20
		0.0f, -0.6f, 0.2f,    0.0f, -0.4f,0.2f,   -0.2f, -0.6f, 0.2f,

		//trian21
		-0.1f, -0.5f, 0.2f,    -0.1f, -0.3f,0.2f,   0.2f, -0.5f, 0.2f,

		//trian22
		0.2f, -0.3f, 0.2f,     -0.1f, -0.3f,0.2f,   0.2f, -0.5f, 0.2f,

		//trian23
		0.5f, 0.1f, 0.2f,    0.5f, -0.2f,0.2f,   0.3f, 0.1f, 0.2f,

		//trian24
		0.3f, -0.2f, 0.2f,    0.5f, -0.2f,0.2f,   0.3f, 0.1f, 0.2f,

		//trian25
		0.4f, 0.2f, 0.2f,    0.6f, 0.2f,0.2f,   0.4f, 0.0f, 0.2f,

		//trian26
		0.6f, 0.0f, 0.2f,    0.6f, 0.2f,0.2f,   0.4f, 0.0f, 0.2f,

		//trian27
		0.3f, -0.3f, 0.2f,    0.5f, -0.3f,0.2f,   0.3f, -0.5f, 0.2f,

		//trian28
		0.5f, -0.5f, 0.2f,    0.5f, -0.3f,0.2f,   0.3f, -0.5f, 0.2f,

		//trian29
		0.6f, -0.6f, 0.2f,    0.6f, -0.4f,0.2f,   0.4f, -0.6f, 0.2f,

		//trian30
		0.4f, -0.4f, 0.2f,    0.6f, -0.4f,0.2f,   0.4f, -0.6f, 0.2f,

		//trian31
		0.5f, -0.5f, 0.2f,    0.8f, -0.5f,0.2f,   0.5f, -0.8f, 0.2f,

		//trian32
		0.8f, -0.8f, 0.2f,    0.8f, -0.5f,0.2f,   0.5f, -0.8f, 0.2f,

		//swordback
		//trian1
		-0.8f, 0.8f, 0.15f,    -0.5f, 0.8f, 0.15f,   -0.8f, 0.5f, 0.15f,

		//trian2
		-0.5f, 0.5f, 0.15f,    -0.5f, 0.8f,0.15f,   -0.8f, 0.5f, 0.15f,

		//trian3
		-0.7f, 0.7f, 0.15f,    -0.4f, 0.7f,0.15f,   -0.7f, 0.4f, 0.15f,

		//trian4
		-0.4f, 0.4f, 0.15f,    -0.4f, 0.7f,0.15f,   -0.7f, 0.4f, 0.15f,

		//trian5
		-0.6f, 0.6f, 0.15f,    -0.3f, 0.6f,0.15f,   -0.6f, 0.3f, 0.15f,

		//trian6
		-0.3f, 0.3f, 0.15f,    -0.3f, 0.6f,0.15f,   -0.6f, 0.3f, 0.15f,

		//trian7
		-0.5f, 0.5f, 0.15f,    -0.2f, 0.5f,0.15f,   -0.5f, 0.2f, 0.15f,

		//trian8
		-0.2f, 0.2f, 0.15f,    -0.2f, 0.5f,0.15f,   -0.5f, 0.2f, 0.15f,

		//trian9
		-0.4f, 0.4f, 0.15f,    -0.1f, 0.4f,0.15f,   -0.4f, 0.1f, 0.15f,

		//trian10
		-0.1f, 0.1f, 0.15f,    -0.1f, 0.4f,0.15f,   -0.4f, 0.1f, 0.15f,

		//trian11
		-0.3f, 0.3f, 0.15f,    0.0f, 0.3f,0.15f,   -0.3f, 0.0f, 0.15f,

		//trian12
		0.0f, 0.0f, 0.15f,    0.0f, 0.3f,0.15f,   -0.3f, 0.0f, 0.15f,

		//trian13
		-0.2f, 0.2f, 0.15f,    0.1f, 0.2f,0.15f,   -0.2f, -0.1f, 0.15f,

		//trian14
		0.1f, -0.1f, 0.15f,    0.1f, 0.2f,0.15f,   -0.2f, -0.1f, 0.15f,

		//trian15
		-0.1f, 0.1f, 0.15f,    0.2f, 0.1f,0.15f,   -0.1f, -0.2f, 0.15f,

		//trian16
		0.2f, -0.2f, 0.15f,    0.2f, 0.1f,0.15f,   -0.1f, -0.2f, 0.15f,

		//trian17
		0.0f, 0.0f, 0.15f,    0.4f, 0.0f,0.15f,   0.0f, -0.4f, 0.15f,

		//trian18
		0.4f, -0.4f, 0.15f,    0.4f, 0.0f,0.15f,   0.0f, -0.4f, 0.15f,

		//trian19
		-0.2f, -0.4f, 0.15f,    0.0f, -0.4f,0.15f,   -0.2f, -0.6f, 0.15f,

		//trian20
		0.0f, -0.6f, 0.15f,    0.0f, -0.4f,0.15f,   -0.2f, -0.6f, 0.15f,

		//trian21
		-0.1f, -0.5f, 0.15f,    -0.1f, -0.3f,0.15f,   0.2f, -0.5f, 0.15f,

		//trian22
		0.2f, -0.3f, 0.15f,     -0.1f, -0.3f,0.15f,   0.2f, -0.5f, 0.15f,

		//trian23
		0.5f, 0.1f, 0.15f,    0.5f, -0.2f,0.15f,   0.3f, 0.1f, 0.15f,

		//trian24
		0.3f, -0.2f, 0.15f,    0.5f, -0.2f,0.15f,   0.3f, 0.1f, 0.15f,

		//trian25
		0.4f, 0.2f, 0.15f,    0.6f, 0.2f,0.15f,   0.4f, 0.0f, 0.15f,

		//trian26
		0.6f, 0.0f, 0.15f,    0.6f, 0.2f,0.15f,   0.4f, 0.0f, 0.15f,

		//trian27
		0.3f, -0.3f, 0.15f,    0.5f, -0.3f,0.15f,   0.3f, -0.5f, 0.15f,

		//trian28
		0.5f, -0.5f, 0.15f,    0.5f, -0.3f,0.15f,   0.3f, -0.5f, 0.15f,

		//trian29
		0.6f, -0.6f, 0.15f,    0.6f, -0.4f,0.15f,   0.4f, -0.6f, 0.15f,

		//trian30
		0.4f, -0.4f, 0.15f,    0.6f, -0.4f,0.15f,   0.4f, -0.6f, 0.15f,

		//trian31
		0.5f, -0.5f, 0.15f,    0.8f, -0.5f,0.15f,   0.5f, -0.8f, 0.15f,

		//trian32
		0.8f, -0.8f, 0.15f,    0.8f, -0.5f,0.15f,   0.5f, -0.8f, 0.15f,


			//swordtop
			//trian1
			-0.8f, 0.8f, 0.2f, -0.5f, 0.8f, 0.2f, -0.5f, 0.8f, 0.15f,

			//trian2
			-0.8f, 0.8f, 0.15f, -0.5f, 0.8f, 0.2f, -0.5f, 0.8f, 0.15f,

			//trian3
			-0.5f, 0.8f, 0.2f, -0.5f, 0.5f, 0.2f, -0.5f, 0.8f, 0.15f,

			//trian4
			-0.5f, 0.5f, 0.2f, -0.5f, 0.8f, 0.15f, -0.5f, 0.5f, 0.15f,
			///////////////////////////
			//trian5
			-0.6f, 0.6f, 0.2f, -0.3f, 0.6f, 0.2f, -0.6f, 0.3f, 0.2f,

			//trian6
			-0.3f, 0.3f, 0.2f, -0.3f, 0.6f, 0.2f, -0.6f, 0.3f, 0.2f,

			//trian7
			-0.5f, 0.5f, 0.2f, -0.2f, 0.5f, 0.2f, -0.5f, 0.2f, 0.2f,

			//trian8
			-0.2f, 0.2f, 0.2f, -0.2f, 0.5f, 0.2f, -0.5f, 0.2f, 0.2f,

			//trian9
			-0.4f, 0.4f, 0.2f, -0.1f, 0.4f, 0.2f, -0.4f, 0.1f, 0.2f,

			//trian10
			-0.1f, 0.1f, 0.2f, -0.1f, 0.4f, 0.2f, -0.4f, 0.1f, 0.2f,

			//trian11
			-0.3f, 0.3f, 0.2f, 0.0f, 0.3f, 0.2f, -0.3f, 0.0f, 0.2f,

			//trian12
			0.0f, 0.0f, 0.2f, 0.0f, 0.3f, 0.2f, -0.3f, 0.0f, 0.2f,

			//trian13
			-0.2f, 0.2f, 0.2f, 0.1f, 0.2f, 0.2f, -0.2f, -0.1f, 0.2f,

			//trian14
			0.1f, -0.1f, 0.2f, 0.1f, 0.2f, 0.2f, -0.2f, -0.1f, 0.2f,

			//trian15
			-0.1f, 0.1f, 0.2f, 0.2f, 0.1f, 0.2f, -0.1f, -0.2f, 0.2f,

			//trian16
			0.2f, -0.2f, 0.2f, 0.2f, 0.1f, 0.2f, -0.1f, -0.2f, 0.2f,

			//trian17
			0.0f, 0.0f, 0.2f, 0.4f, 0.0f, 0.2f, 0.0f, -0.4f, 0.2f,

			//trian18
			0.4f, -0.4f, 0.2f, 0.4f, 0.0f, 0.2f, 0.0f, -0.4f, 0.2f,

			//trian19
			-0.2f, -0.4f, 0.2f, 0.0f, -0.4f, 0.2f, -0.2f, -0.6f, 0.2f,

			//trian20
			0.0f, -0.6f, 0.2f, 0.0f, -0.4f, 0.2f, -0.2f, -0.6f, 0.2f,

			//trian21
			-0.1f, -0.5f, 0.2f, -0.1f, -0.3f, 0.2f, 0.2f, -0.5f, 0.2f,

			//trian22
			0.2f, -0.3f, 0.2f, -0.1f, -0.3f, 0.2f, 0.2f, -0.5f, 0.2f,

			//trian23
			0.5f, 0.1f, 0.2f, 0.5f, -0.2f, 0.2f, 0.3f, 0.1f, 0.2f,

			//trian24
			0.3f, -0.2f, 0.2f, 0.5f, -0.2f, 0.2f, 0.3f, 0.1f, 0.2f,

			//trian25
			0.4f, 0.2f, 0.2f, 0.6f, 0.2f, 0.2f, 0.4f, 0.0f, 0.2f,

			//trian26
			0.6f, 0.0f, 0.2f, 0.6f, 0.2f, 0.2f, 0.4f, 0.0f, 0.2f,

			//trian27
			0.3f, -0.3f, 0.2f, 0.5f, -0.3f, 0.2f, 0.3f, -0.5f, 0.2f,

			//trian28
			0.5f, -0.5f, 0.2f, 0.5f, -0.3f, 0.2f, 0.3f, -0.5f, 0.2f,

			//trian29
			0.6f, -0.6f, 0.2f, 0.6f, -0.4f, 0.2f, 0.4f, -0.6f, 0.2f,

			//trian30
			0.4f, -0.4f, 0.2f, 0.6f, -0.4f, 0.2f, 0.4f, -0.6f, 0.2f,

			//trian31
			0.5f, -0.5f, 0.2f, 0.8f, -0.5f, 0.2f, 0.5f, -0.8f, 0.2f,

			//trian32
			0.8f, -0.8f, 0.2f, 0.8f, -0.5f, 0.2f, 0.5f, -0.8f, 0.2f,




	};

	glBufferData(GL_ARRAY_BUFFER, 2592 * sizeof(float), vertices, GL_STATIC_DRAW);
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	GLuint shp = glCreateProgram();

	const GLchar *vcode = "#version 120\n"
		"attribute vec3 pos;"
		"uniform mat4 matr;"
		"void main(){"
		"gl_Position = matr*vec4(pos,1);"
		"}";

	GLint vlen = std::string(vcode).length();

	GLuint vsh = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vsh, 1, &vcode, &vlen);
	glAttachShader(shp, vsh);
	glCompileShader(vsh);
	GLint success;
	glGetShaderiv(vsh, GL_COMPILE_STATUS, &success);
	if (!success) {
		GLchar InfoLog[1024];
		glGetShaderInfoLog(vsh, sizeof(InfoLog), NULL, InfoLog);
		printf("Error compiling shader type %d: '%s'\n", vsh, InfoLog);
	}
	const GLchar *fcode = "#version 120\n"
		"void main(){"
		"gl_FragColor = vec4(0,1,1,0.5);"
		"}";
	GLint flen = std::string(fcode).length();
	GLuint fsh = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fsh, 1, &fcode, &flen);
	glAttachShader(shp, fsh);
	glCompileShader(fsh);
	glGetShaderiv(fsh, GL_COMPILE_STATUS, &success);
	if (!success) {
		GLchar InfoLog[1024];
		glGetShaderInfoLog(fsh, sizeof(InfoLog), NULL, InfoLog);
		//printf("Error compiling shader type %d: '%s'\n", fsh, InfoLog);
	}
	glValidateProgram(shp);
	glLinkProgram(shp);
	glUseProgram(shp);
	matloc = glGetUniformLocation(shp, "matr");
	posloc = glGetAttribLocation(shp, "pos");
	glBindBuffer(GL_ARRAY_BUFFER, vbo);
	glVertexAttribPointer(posloc, 3, GL_FLOAT, GL_FALSE, 0, 0);
	glutDisplayFunc(display);
	glutIdleFunc(idol);
	glutMainLoop();
	return 0;

}