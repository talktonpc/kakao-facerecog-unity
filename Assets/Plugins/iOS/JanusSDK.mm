#import <Foundation/Foundation.h>
#import "JanusSDKWrapper.h"
#import "JanusSDK.h"

#define JANUS_SDK_EXTERNC extern "C"

//==============================================================================================================================
NSString* JanusSDKMakeNSString (const char* string) {
    if (string) {
        return [NSString stringWithUTF8String: string];
    } else {
        return [NSString stringWithUTF8String: ""];
    }
}

char* JanusSDKMakeCString(NSString *str) {
    const char* string = [str UTF8String];
    if (string == NULL) {
        return NULL;
    }

    char *buffer = (char*)malloc(strlen(string) + 1);
    strcpy(buffer, string);
    return buffer;
}

//==============================================================================================================================
JANUS_SDK_EXTERNC void janus_init();
JANUS_SDK_EXTERNC int trackFace_RGBA(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize);
JANUS_SDK_EXTERNC int trackFace_BGRA(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize);
JANUS_SDK_EXTERNC int trackFace_RGB(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize);

// Detect
JANUS_SDK_EXTERNC int detectFace_BGRA(unsigned char* img, int width, int height, bool bRecognize);

// Alignment
JANUS_SDK_EXTERNC int getFacialPoints(int idx, float* pts);
JANUS_SDK_EXTERNC int getAlignmentPoints(int idx, float* pts);
JANUS_SDK_EXTERNC int getFacialRect(int idx, int* pRect);
JANUS_SDK_EXTERNC int getFDRect(int idx, int* pRect);
JANUS_SDK_EXTERNC int getFacialProb(int idx);

// Recognition
JANUS_SDK_EXTERNC int getFaceFeature(int idx, float* feature);
JANUS_SDK_EXTERNC int getFaceAngles(int idx, float* angles);
JANUS_SDK_EXTERNC int getID(int idx);

// Attribute
JANUS_SDK_EXTERNC float getLiveness(int idx);
JANUS_SDK_EXTERNC float getMaskLevel(int idx);
JANUS_SDK_EXTERNC int setAttributeEnabled(bool b);

// power state
JANUS_SDK_EXTERNC int getCurrentPowerState();
JANUS_SDK_EXTERNC void setPowerControl(bool b);

// WTM
JANUS_SDK_EXTERNC int loadGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx);
JANUS_SDK_EXTERNC int addGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx);
JANUS_SDK_EXTERNC char* getRecognizedName(int idx);
JANUS_SDK_EXTERNC char* getPipelineLog();
JANUS_SDK_EXTERNC char* getFaceLog(int idx);
JANUS_SDK_EXTERNC int setFaceRecognitionThreshold(float value);
JANUS_SDK_EXTERNC void setFaceDetectionThreshold(float value);
JANUS_SDK_EXTERNC int setMaximumFaceNumber(int cnt);
JANUS_SDK_EXTERNC int setMinimumFaceSize(int size);
JANUS_SDK_EXTERNC int clearDB();
JANUS_SDK_EXTERNC int eraseFaceIDFromDB(char* pID);

// Basic
JANUS_SDK_EXTERNC int doReInit();
JANUS_SDK_EXTERNC int doFinalize();
JANUS_SDK_EXTERNC void doClose();

// version
JANUS_SDK_EXTERNC char* getVersion();

//==============================================================================================================================
JANUS_SDK_EXTERNC void janus_sdk_UnitySendMessage(const char *name, const char *method, NSString *params) {
    UnitySendMessage(name, method, JanusSDKMakeCString(params));
}

JanusObj *jo = nil;

//==============================================================================================================================
void janus_init() {
    
    NSBundle *bundle = [NSBundle bundleForClass:[JanusObj class]];
    NSString *modelpath = [bundle pathForResource:@"kaen_mlmodelc_english" ofType:@"bin"];
    
    if( jo == nil ) jo = [[[JanusObj alloc] init] init:modelpath];

    [jo setPowerControl:false];
    [jo setMaximumFaceNumber:1];
    [jo setMinimumFaceSize:100];
    [jo setFaceDetectionThreshold:0.9];
    
    NSString *version = [jo getVersion];
    NSLog(@"Janus version : %@", version);
    NSLog(@"Janus model : %@", modelpath);
}

int trackFace_RGBA(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize) {
    return [jo trackFace_RGBA:img width:width height:height angle_in_degree:angle_in_degree bRecognize:bRecognize];
}
int trackFace_BGRA(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize) {
    return [jo trackFace_BGRA:img width:width height:height angle_in_degree:angle_in_degree bRecognize:bRecognize];
}
int trackFace_RGB(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize) {
    return [jo trackFace_RGB:img width:width height:height angle_in_degree:angle_in_degree bRecognize:bRecognize];
}

// Detect
int detectFace_BGRA(unsigned char* img, int width, int height, bool bRecognize) {
    return [jo detectFace_BGRA:img width:width height:height bRecognize:bRecognize];
}

// Alignment
int getFacialPoints(int idx, float* pts) {
    return [jo getFacialPoints:idx pts:pts];
}
int getAlignmentPoints(int idx, float* pts) {
    return [jo getAlignmentPoints:idx pts:pts];
}
int getFacialRect(int idx, int* pRect) {
    return [jo getFacialRect:idx pRect:pRect];
}
int getFDRect(int idx, int* pRect) {
    return [jo getFDRect:idx pRect:pRect];
}
int getFacialProb(int idx) {
    return [jo getFacialProb:idx];
}

// Recognition
int getFaceFeature(int idx, float* feature) {
    return [jo getFaceFeature:idx feature:feature];
}
int getFaceAngles(int idx, float* angles) {
    return [jo getFaceAngles:idx angles:angles];
}
int getID(int idx) {
   return [jo getID:idx];
}

// Attribute
float getLiveness(int idx) {
    return [jo getLiveness:idx];
}
float getMaskLevel(int idx) {
    return [jo getMaskLevel:idx];
}
int setAttributeEnabled(bool b) {
    return [jo setAttributeEnabled:b];
}

// power state
int getCurrentPowerState() {
   return [jo getCurrentPowerState];
}
void setPowerControl(bool b) {
    [jo setPowerControl:b];
}

// WTM
int loadGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx) {
    return [jo loadGalleryFeature:gallery_features numOfIdx:numOfIdx];
}
int addGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx) {
    return [jo addGalleryFeature:gallery_features numOfIdx:numOfIdx];
}
char* getRecognizedName(int idx) {
    NSString* ns = [jo getRecognizedName:idx];
    return JanusSDKMakeCString(ns);
}
char* getPipelineLog() {
    NSString* ns = [jo getPipelineLog];
    return JanusSDKMakeCString(ns);
}
char* getFaceLog(int idx) {
    NSString* ns = [jo getFaceLog:idx];
    return JanusSDKMakeCString(ns);
}
int setFaceRecognitionThreshold(float value) {
    return [jo setFaceRecognitionThreshold:value];
}
void setFaceDetectionThreshold(float value) {
    [jo setFaceDetectionThreshold:value];
}
int setMaximumFaceNumber(int cnt) {
    return [jo setMaximumFaceNumber:cnt];
}
int setMinimumFaceSize(int size) {
    return [jo setMinimumFaceSize:size];
}
int clearDB() {
    return [jo clearDB];
}
int eraseFaceIDFromDB(char* pID) {
    NSString* ns = JanusSDKMakeNSString(pID);
    return [jo eraseFaceIDFromDB:ns];
}

// Basic
int doReInit() {
    return [jo doReInit];
}
int doFinalize() {
    return [jo doFinalize];
}
void doClose() {
    [jo close];
}

// version
char* getVersion() {
    NSString* ns = [jo getVersion];
    return JanusSDKMakeCString(ns);
}
