package com.demo.log;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.json.JSONObject;
import org.json.JSONException;
import java.time.Instant;

@SpringBootApplication
@RestController
public class LogApplication {
	Logger logger = LoggerFactory.getLogger(LogApplication.class);

	public static void main(String[] args) {
		SpringApplication.run(LogApplication.class, args);
	}

	@CrossOrigin
	@GetMapping("/log")
	public String log(@RequestParam(defaultValue = "empty logs") String log) throws JSONException {
		logger.info(log);
		return "";
	}
}
