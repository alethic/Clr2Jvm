#include <jni.h>
#include <stdio.h>

JNIEXPORT void JNICALL
Java_solutions_alethic_jnidotnet_Bridge_print(JNIEnv *env, jobject obj)
{
printf("Hello World!\n");
return;
}