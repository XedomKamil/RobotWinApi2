/******************************************************************************
 * Copyright (c) 2012-2017 All Rights Reserved, http://www.evocortex.com      *
 *  Evocortex GmbH                                                            *
 *  Emilienstr. 1                                                             *
 *  90489 Nuremberg                                                           *
 *  Germany                                                                   *
 *                                                                            *
 * Contributors:                                                              *
 *  Initial version for Linux 64-Bit platform supported by Fraunhofer IPA,    *
 *  http://www.ipa.fraunhofer.de                                              *
 *****************************************************************************/

#pragma once

#include "unicode.h"
#include <iostream>
#include "irdirectsdk_defs.h"
#include <vector>

namespace evo
{

enum EnumFlagState        { irFlagOpen, irFlagClose, irFlagOpening, irFlagClosing, irFlagError};


/**
 * @brief Enum Input type of the event
 * 
 */
struct IREventInputType
{
  enum Value
  {
    DigitalInput, ///< Triggered by digital input
    AnalogInput,  ///< Triggered by analog input
    Software      ///< Triggered by software
  };
};

/**
 * @brief Enum Type of the event
 * 
 */
struct IREventType
{
  enum Value
  {
    Snapshot,       ///< Event source is snapshot
    SnapshotOnEdge  ///< Event source is snapshot on edge
  };
};

/**
 * @brief Enum Specifies the connected pif
 * 
 */
struct IRPifType
{
  enum Value
  {
    None,       ///< Invalid or none pif
    PI,         ///< Extern PI PIF
    PImV,       ///< Extern PI PIF with 0..10 Voltage Output
    Intern,     ///< Intern pif 
    Stackable,  ///< Extern stackable pif
    PImA,       ///< Extern PI PIF with 0..20 mA Output
  };
};


/**
 * @struct IREventData
 * @brief Structure containing event data information
 * @author Helmut Engelhardt (Evocortex GmbH)
 */
struct IREventData {
  IREventData(IREventInputType::Value inputType,  unsigned char channel, IREventType::Value eventType) :
    inputType(inputType), channel(channel), eventType(eventType)
  {}

  IREventInputType::Value inputType;  /*!< Input type of event */
  unsigned char channel;            /*!< Analog or digital input channel of event */
  IREventType::Value eventType;       /*!< Event type of event */
};

/**
 * @struct IRFrameMetadata
 * @brief Structure containing meta data acquired from the PI imager
 * @author Stefan May (Evocortex GmbH), Helmut Engelhardt (Evocortex GmbH), Matthias Wiedemann (Optris GmbH)
 */
struct IRFrameMetadata
{
  unsigned short size;      /*!< Size of this structure */
  unsigned int counter;     /*!< Consecutively numbered for each received frame */
  unsigned int counterHW;   /*!< Hardware counter received from device, multiply with value returned by IRImager::getAvgTimePerFrame() to get a hardware timestamp */
  long long timestamp;      /*!< Time stamp in UNITS (10000000 per second) */
  long long timestampMedia;
  EnumFlagState flagState;  /*!< State of shutter flag at capturing time */
  float tempChip;           /*!< Chip temperature */
  float tempFlag;           /*!< Shutter flag temperature */
  float tempBox;            /*!< Temperature inside camera housing */
  unsigned short pifIn;     /*!< Deprecated! */
  std::vector<bool> pifDIs; /*!< List of digital input values */
  std::vector<float> pifAIs;/*!< List of analog input voltages */
};

enum EnumOutputMode       { Energy = 1, Temperature = 2 };

/**
 * @struct IRDeviceParams
 * @brief Structure containing device parameters
 * @author Stefan May (Evocortex GmbH), Matthias Wiedemann (Optris GmbH)
 */
struct IRDeviceParams
{
  unsigned long serial;             /*!< serial number */
  int fov;                          /*!< Field of view */
  Tchar* opticsText;                /*!<  */
  Tchar* formatsPath;               /*!< Path to Format.def file  */
  Tchar* caliPath;                  /*!< Path to calibration files */
  int tMin;                         /*!< Minimum of temperature range */
  int tMax;                         /*!< Maximum of temperature range */
  float framerate;                  /*!< Frame rate */
  int videoFormatIndex;             /*!< Used video format index, if multiple modes are supported by the device, e.g. PI400 format index 0: 32 Hz, 1: 80 Hz. */
  int bispectral;                   /*!< Use bi-spectral mode, if available (e.g. PI200). */
  int average;                      /*!< Activate average filter, if data stream is subsampled. */
  int autoFlag;                     /*!< Use auto flag procedure. */
  float minInterval;                /*!< Minimum interval for a flag cycle. It defines the time in which a flag cycle is forced at most once.*/
  float maxInterval;                /*!< Maximum interval for a flag cycle. It defines the time in which a flag cycle is forced at least once. */
  int tChipMode;                    /*!< Chip heating: 0=Floating, 1=Auto, 2=Fixed value */
  float tChipFixedValue;            /*!< Fixed value for tChipMode=2 */
  float focus;                      /*!< position of focus motor in % of range [0; 100] */
  bool enableExtendedTempRange;     /*!< 0=Off, 1=On; Caution! Enables invalid extended temp range*/
  unsigned short bufferQueueSize;    /*!< 0=Off, 1=On; Caution! Enables invalid extended temp range*/
};

void IRDeviceParams_InitDefault(IRDeviceParams &params);

void IRDeviceParams_Print(IRDeviceParams params);

/**
 * @class IRDeviceParamsReader
 * @brief Helper class for reading PI imager configuration files
 * @author Stefan May (Evocortex GmbH), Matthias Wiedemann (Optris GmbH)
 */
class __IRDIRECTSDK_API__ IRDeviceParamsReader
{
public:

  /**
   * Static xml parsing method
   * @param[in] xmlFile path to xml configuration file
   * @param[out] params imager parameters read from xml file
   */
  static bool readXML(const Tchar* xmlFile, IRDeviceParams &params);

  /**
   * Static xml parsing method for 8-bit character path
   * @param[in] xmlFile path to xml configuration file
   * @param[out] params imager parameters read from xml file
   */
  static bool readXMLC(const char* xmlFile, IRDeviceParams &params);

private:

  /**
  * Constructor
  */
  IRDeviceParamsReader() {};

  /**
   * Destructor
   */
  ~IRDeviceParamsReader() {};
};

}
