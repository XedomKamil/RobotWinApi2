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

#ifndef DIRECT_BINDING_H_
#define DIRECT_BINDING_H_

#include "irdirectsdk_defs.h"

#ifdef  __cplusplus
extern "C" {
#endif

/**
 * @brief Initializes an IRImager instance connected to this computer via USB
 * @param[in] xml_config path to xml config
 * @param[in] formats_def path to Formats.def file. Set zero for standard value.
 * @param[in] log_file path to log file. Set zero for standard value.
 * @return 0 on success, -1 on error
 */
__IRDIRECTSDK_API__ int evo_irimager_usb_init(const char* xml_config, const char* formats_def, const char* log_file);

/**
 * @brief Initializes the TCP connection to the daemon process (non-blocking)
 * @param[in] IP address of the machine where the daemon process is running ("localhost" can be resolved)
 * @param port Port of daemon, default 1337
 * @return  error code: 0 on success, -1 on host not found (wrong IP, daemon not running), -2 on fatal error
 */
__IRDIRECTSDK_API__ int evo_irimager_tcp_init(const char* ip, int port);

/**
 * @brief Disconnects the camera, either connected via USB or TCP
 * @return 0 on success, -1 on error
 */
__IRDIRECTSDK_API__ int evo_irimager_terminate();

/**
 * @brief Accessor to image width and height
 * @param[out] w width
 * @param[out] h height
 * @return 0 on success, -1 on error
 */
__IRDIRECTSDK_API__ int evo_irimager_get_thermal_image_size(int* w, int* h);

/**
 * @brief Accessor to width and height of false color coded palette image
 * @param[out] w width
 * @param[out] h height
 * @return 0 on success, -1 on error
 */
__IRDIRECTSDK_API__ int evo_irimager_get_palette_image_size(int* w, int* h);

/**
 * @brief Accessor to thermal image by reference
 * Conversion to temperature values are to be performed as follows:
 * t = ((double)data[x] - 1000.0) / 10.0;
 * @param[in] w image width
 * @param[in] h image height
 * @param[out] data pointer to unsigned short array allocate by the user (size of w * h)
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_get_thermal_image(int* w, int* h, unsigned short* data);

/**
 * @brief Accessor to an RGB palette image by reference
 * data format: unsigned char array (size 3 * w * h) r,g,b
 * @param[in] w image width
 * @param[in] h image height
 * @param[out] data pointer to unsigned char array allocate by the user (size of 3 * w * h)
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_get_palette_image(int* w, int* h, unsigned char* data);

/**
 * @brief Accessor to an RGB palette image and a thermal image by reference
 * @param[in] w_t width of thermal image
 * @param[in] h_t height of thermal image
 * @param[out] data_t data pointer to unsigned short array allocate by the user (size of w * h)
 * @param[in] w_p width of palette image (can differ from thermal image width due to striding)
 * @param[in] h_p height of palette image (can differ from thermal image height due to striding)
 * @param[out] data_p data pointer to unsigned char array allocate by the user (size of 3 * w * h)
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_get_thermal_palette_image(int w_t, int h_t, unsigned short* data_t, int w_p, int h_p, unsigned char* data_p );

/**
 * @brief sets palette format to daemon.
 * Defined in IRImager Direct-SDK, see
 * enum EnumOptrisColoringPalette{eAlarmBlue   = 1,
 *                                eAlarmBlueHi = 2,
 *                                eGrayBW      = 3,
 *                                eGrayWB      = 4,
 *                                eAlarmGreen  = 5,
 *                                eIron        = 6,
 *                                eIronHi      = 7,
 *                                eMedical     = 8,
 *                                eRainbow     = 9,
 *                                eRainbowHi   = 10,
 *                                eAlarmRed    = 11 };
 *
 * @param id palette id
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_set_palette(int id);

/**
 * @brief sets palette scaling method
 * Defined in IRImager Direct-SDK, see
 * enum EnumOptrisPaletteScalingMethod{eManual = 1,
 *                                     eMinMax = 2,
 *                                     eSigma1 = 3,
 *                                     eSigma3 = 4 };
 * @param scale scaling method id
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_set_palette_scale(int scale);

/**
 * @brief sets shutter flag control mode
 * @param mode 0 means manual control, 1 means automode
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_set_shutter_mode(int mode);

/**
 * @brief forces a shutter flag cycle
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_trigger_shutter_flag();

/**
 * @brief sets the minimum and maximum remperature range to the camera (also configurable in xml-config)
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_set_temperature_range(int t_min, int t_max);

/**
 * @brief sets radiation properties, i.e. emissivity and transmissivity parameters (not implemented for TCP connection, usb mode only)
 * @param[in] emissivity emissivity of observed object [0;1]
 * @param[in] transmissivity transmissivity of observed object [0;1]
 * @param[in] tAmbient ambient temperature, setting invalid values (below -273,15 degrees) forces the library to take its own measurement values.
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_set_radiation_parameters(float emissivity, float transmissivity, float tAmbient);

/**
* @brief 
* @return error code: 0 on success, -1 on error
*/
__IRDIRECTSDK_API__ int evo_irimager_to_palette_save_png(unsigned short* thermal_data, int w, int h, const char* path, int palette, int palette_scale);

/**
 * @brief Set the position of the focusmotor
 * @param[in] pos fucos motor position in %
 * @return error code: 0 on success, -1 on error or if no focusmotor is available
 */
__IRDIRECTSDK_API__ int evo_irimager_set_focusmotor_pos(float pos);

/**
 * @brief Get the position of the focusmotor
 * @param[out] posOut Data pointer to float for current fucos motor position in % (< 0 if no focusmotor available)
 * @return error code: 0 on success, -1 on error
 */
__IRDIRECTSDK_API__ int evo_irimager_get_focusmotor_pos(float *posOut);

/**
 * Launch TCP daemon
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_daemon_launch();

/**
 * Check whether daemon is already running
 * @return error code: 0 daemon is already active, -1 daemon is not started yet
 */
__IRDIRECTSDK_API__ int evo_irimager_daemon_is_running();

/**
 * Kill TCP daemon
 * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
 */
__IRDIRECTSDK_API__ int evo_irimager_daemon_kill();

#ifdef  __cplusplus
}
#endif



#endif /* DIRECT_BINDING_H_ */
