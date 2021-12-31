//=====================================================================================
//  JanusSDKWrapper.h
//
//  Created by lonycell on 2021. 12. 29.
//=====================================================================================
#ifndef JanusSDKWrapper_h
#define JanusSDKWrapper_h

#import <Foundation/Foundation.h>

@interface JanusObj : NSObject
    typedef struct _objectInfoWrapper
    {
        int objectID;
        float *featurevec;
    } objectInfoWrapper;

    typedef struct _galleryInfoWrapper
    {
        __unsafe_unretained NSString *personID;
        int numFeatureVec;
        float *feature_vec_list;
    } galleryInfoWrapper;

    // Initializer
    - (instancetype)init:(NSString *)package_model_path;

    // Detector
    - (int)trackFace_RGBA:(unsigned char *)img
                    width:(int)width
                height:(int)height
        angle_in_degree:(int)angle_in_degree
            bRecognize:(Boolean)bRecognize;

    - (int)trackFace_BGRA:(unsigned char *)img
                    width:(int)width
                height:(int)height
        angle_in_degree:(int)angle_in_degree
            bRecognize:(Boolean)bRecognize;

    - (int)trackFace_RGB:(unsigned char *)img
                width:(int)width
                height:(int)height
        angle_in_degree:(int)angle_in_degree
            bRecognize:(Boolean)bRecognize;

    // Detect
    - (int)detectFace_BGRA:(unsigned char *)img
                    width:(int)width
                height:(int)height
            bRecognize:(Boolean)bRecognize;

    // Alignment
    - (int)getFacialPoints:(int)idx pts:(float *)pts;
    - (int)getAlignmentPoints:(int)idx pts:(float *)pts;
    - (int)getFacialRect:(int)idx pRect:(int*)pRect;
    - (int)getFDRect:(int)idx pRect:(int*)pRect;
    - (float)getFacialProb:(int)idx;

    // Recognition
    - (int)getFaceFeature:(int)idx
                feature:(float*)feature;
    - (int)getFaceAngles:(int)idx
                angles:(float*)angles;
    - (int)getID:(int)idx;

    // Attribute
    - (float)getLiveness:(int)idx;
    - (float)getMaskLevel:(int)idx;
    - (int)setAttributeEnabled:(bool)b;

    // power state
    - (int)getCurrentPowerState;
    - (void)setPowerControl:(bool )b;

    // WTM
    - (int)loadGalleryFeature:(galleryInfoWrapper*)gallery_features
                    numOfIdx:(int)numOfIdx;
    - (int)addGalleryFeature:(galleryInfoWrapper*)gallery_features
                    numOfIdx:(int)numOfIdx;
    - (NSString*)getRecognizedName:(int)idx;
    - (NSString*)getPipelineLog;
    - (NSString*)getFaceLog:(int)idx;
    - (int)setFaceRecognitionThreshold:(float)value;
    - (void)setFaceDetectionThreshold:(float)value;
    - (int)setMaximumFaceNumber:(int)cnt;
    - (int)setMinimumFaceSize:(int)size;
    - (int)clearDB;
    - (int)eraseFaceIDFromDB:(NSString *)pID;

    // Basic
    - (int)doReInit;
    - (int)doFinalize;
    - (void)close;

    // version
    - (NSString*)getVersion;

@end

#endif /* JanusSDKWrapper_h */
