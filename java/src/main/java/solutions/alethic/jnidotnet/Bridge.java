package solutions.alethic.jnidotnet;

public class Bridge {

    static {
        System.loadLibrary("jnidotnet-jni");
    }

    public native void print();

}
