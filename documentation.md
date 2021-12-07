# API Documentation
---
## Accessing the endpoint
> *GET* /api/data/getLoans
Returns the date and count for:
Compliance Review, Compliance Review Suspense, Purchase Review and Purchase Review Suspense.

> Example return (in JSON format)
```json
	{
		"complianceReviewCount":5,
		"complianceReviewDate":"7/16/2021 3:36:20 PM",
		"complianceReviewSuspenseCount":1,
		"complianceReviewSuspenseDate":"7/16/2021 4:06:36 PM",
		"purchaseReviewCount":2,
		"purchaseReviewDate":"9/16/2021 12:16:27 PM",
		"purchaseReviewSuspenseCount":1,
		"purchaseReviewSuspenseDate":"8/31/2021 9:34:50 AM"
	}
```
---
## Deployment
1. Build the project
1. Run the executable CALHFA_API.exe (in /CalHFA_API/bin/Debug/net5.0)
---
