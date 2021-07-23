plugins {
    id("java")
    id("dev.nokee.jni-library")
    id("dev.nokee.c-language")
    id("maven-publish")
    id("solutions.alethic.gradle.plugins.jni-library-publish")
}

group = "solutions.alethic"
version = "1.0-SNAPSHOT"

library {
    targetMachines.set(listOf(
        machines.windows.x86_64,
        machines.macOS.x86_64,
        machines.linux.x86_64
    ))
}

repositories {
    mavenCentral()
}

afterEvaluate {
    publishing {
        publications {
            create<MavenPublication>("jniLibrary") {
                from(components.getByName("jni"))
                artifactId = project.name
            }
            create<MavenPublication>("jniLibraryMacos") {
                from(components.getByName("jniMacos"))
                artifactId = "${project.name}-macos"
            }
            create<MavenPublication>("jniLibraryLinux") {
                from(components.getByName("jniLinux"))
                artifactId = "${project.name}-linux"
            }
            create<MavenPublication>("jniLibraryWindows") {
                from(components.getByName("jniWindows"))
                artifactId = "${project.name}-windows"
            }
        }
        repositories {
            maven {
                url = uri("${buildDir}/publishing-repository")
            }
        }
    }
}

dependencies {
    testImplementation("org.junit.jupiter:junit-jupiter:5.7.2")
}