*eventcreate2* is an alternative implementation of Microsoft's eventcreate command.

If this error is familiar, you're in the right place:

> eventcreate /l "test" /so "test" /d "hello world" /t information /id 1

> ERROR: 'test' log does not exist. Cannot create the event.

When run as administrator, *eventcreate2* will automatically create custom event logs, where eventcreate (the original) does not.

> eventcreate2 /l "test" /so "test" /d "hello world" /t information /id 1

*Note:* After running the command, restart event viewer (if running), your log will appear under "Applications and Sevrices logs".
